using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
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
        private readonly string CLIENT_ID;
        private readonly string CLIENT_SECRET;

        private static readonly string[] Scopes = {
            Oauth2Service.Scope.UserinfoEmail,
            Oauth2Service.Scope.UserinfoProfile
        };

        public GoogleAuthService()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            CLIENT_ID = config["GoogleAuth:ClientId"];
            CLIENT_SECRET = config["GoogleAuth:ClientSecret"];
        }

        public async Task<(bool Success, string Email, string FullName, string Error)> AuthenticateAsync()
        {
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

                var listener = new HttpListener();
                listener.Prefixes.Add(redirectUri);
                listener.Start();

                // Mở browser
                Process.Start(new ProcessStartInfo
                {
                    FileName = authUrl.Build().ToString(),
                    UseShellExecute = true
                });

                // Đợi callback
                var context = await listener.GetContextAsync();
                var code = context.Request.QueryString.Get("code");

                string html = @"
                    <html>
                        <head>
                            <meta charset='UTF-8'>
                            <title>Đang xử lý...</title>
                        </head>
                        <body onload='window.open(window.location, ""_self"").close();' style='font-family: Arial, sans-serif; text-align: center; padding-top: 50px;'>
                            <h2>Đăng nhập thành công!</h2>
                            <p>Bạn có thể đóng tab này và quay lại ứng dụng.</p>
                        </body>
                    </html>";

                var buffer = System.Text.Encoding.UTF8.GetBytes(html);
                context.Response.ContentEncoding = System.Text.Encoding.UTF8;
                context.Response.ContentType = "text/html; charset=utf-8";
                context.Response.ContentLength64 = buffer.Length;
                await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();

                await Task.Delay(500);

                listener.Stop();

                if (string.IsNullOrEmpty(code))
                {
                    return (false, null, null, "Không nhận được authorization code.");
                }

                var token = await flow.ExchangeCodeForTokenAsync("user", code, redirectUri, CancellationToken.None);
                var credential = new UserCredential(flow, "user", token);

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