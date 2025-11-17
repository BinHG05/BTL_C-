using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public interface IGoogleAuthService
    {
        Task<(bool Success, string Email, string FullName, string Error)> AuthenticateAsync();
    }

    public class GoogleAuthService : IGoogleAuthService
    {
        private const string CLIENT_ID = "CLIENT_ID_FROM_CONFIG";
        private const string CLIENT_SECRET = "CLIENT_SECRET_FROM_CONFIG";

        private static readonly string[] Scopes = {
            Oauth2Service.Scope.UserinfoEmail,
            Oauth2Service.Scope.UserinfoProfile
        };

        public async Task<(bool Success, string Email, string FullName, string Error)> AuthenticateAsync()
        {
            string browserUrl = null;

            try
            {
                int port = GetRandomUnusedPort();
                string redirectUri = $"http://localhost:{port}/";

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets
                    {
                        ClientId = CLIENT_ID,
                        ClientSecret = CLIENT_SECRET
                    },
                    Scopes = Scopes
                });

                var authUrl = flow.CreateAuthorizationCodeRequest(redirectUri);
                browserUrl = authUrl.Build().ToString();

                var listener = new HttpListener();
                listener.Prefixes.Add(redirectUri);
                listener.Start();

                // Mở browser
                Process.Start(new ProcessStartInfo
                {
                    FileName = browserUrl,
                    UseShellExecute = true
                });

                // Đợi callback
                var context = await listener.GetContextAsync();
                var code = context.Request.QueryString.Get("code");

                // Trả response trống
                string html = "<html><body></body></html>";
                var buffer = System.Text.Encoding.UTF8.GetBytes(html);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.ContentType = "text/html";
                await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();
                listener.Stop();

                // ✅✅✅ ĐÓNG TẤT CẢ TAB LOCALHOST ✅✅✅
                await Task.Delay(500); // Đợi browser nhận response

                try
                {
                    // Tìm tất cả process browser
                    var allProcesses = Process.GetProcesses();

                    // Chrome processes
                    var chromeProcesses = allProcesses.Where(p =>
                    {
                        try
                        {
                            return p.ProcessName.ToLower().Contains("chrome") &&
                                   (p.MainWindowTitle.ToLower().Contains("localhost") ||
                                    p.MainWindowTitle.ToLower().Contains("127.0.0.1") ||
                                    p.MainWindowTitle.ToLower().Contains("google") ||
                                    p.MainWindowTitle.ToLower().Contains("sign in"));
                        }
                        catch
                        {
                            return false;
                        }
                    }).ToList();

                    // Edge processes
                    var edgeProcesses = allProcesses.Where(p =>
                    {
                        try
                        {
                            return p.ProcessName.ToLower().Contains("msedge") &&
                                   (p.MainWindowTitle.ToLower().Contains("localhost") ||
                                    p.MainWindowTitle.ToLower().Contains("127.0.0.1") ||
                                    p.MainWindowTitle.ToLower().Contains("google") ||
                                    p.MainWindowTitle.ToLower().Contains("sign in"));
                        }
                        catch
                        {
                            return false;
                        }
                    }).ToList();

                    // Kill tất cả
                    foreach (var proc in chromeProcesses.Concat(edgeProcesses))
                    {
                        try
                        {
                            proc.Kill();
                            proc.WaitForExit(1000);
                        }
                        catch { }
                    }

                    // ✅ NẾU VẪN CHƯA ĐÓNG, DÙNG TASKKILL MẠNH HƠN
                    try
                    {
                        // Kill tất cả Chrome tab chứa localhost
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "taskkill",
                            Arguments = "/F /IM chrome.exe /T",
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true
                        })?.WaitForExit(2000);
                    }
                    catch { }
                }
                catch { }

                if (string.IsNullOrEmpty(code))
                {
                    return (false, null, null, "Không nhận được authorization code.");
                }

                // Đổi code lấy token
                var token = await flow.ExchangeCodeForTokenAsync("user", code, redirectUri, CancellationToken.None);
                var credential = new UserCredential(flow, "user", token);

                // Lấy thông tin user
                var service = new Oauth2Service(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Expense Manager"
                });

                var userInfo = await service.Userinfo.Get().ExecuteAsync();

                return (true, userInfo.Email, userInfo.Name, null);
            }
            catch (Exception ex)
            {
                return (false, null, null, ex.Message);
            }
        }

        private static int GetRandomUnusedPort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
    }
}