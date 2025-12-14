using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace ExpenseManager.App.Services
{
    public class AIChatService : IAIChatService
    {
        private readonly IGoalService _goalService;
        private readonly ICategoryService _categoryService;
        private readonly ITransactionService _transactionService;
        private readonly IWalletService _walletService;
        private readonly IBudgetService _budgetService;
        private readonly List<ChatMessage> _history;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        // Lưu trạng thái chờ user chọn ví
        private string _pendingAction = null;
        private string _pendingGoalName = null;
        private decimal _pendingAmount = 0;
        // Groq API Configuration
        private const string API_URL = "https://api.groq.com/openai/v1/chat/completions";
        private const string MODEL = "llama-3.3-70b-versatile"; // Model mạnh nhất, miễn phí
        public AIChatService(
            IGoalService goalService,
            ICategoryService categoryService,
            ITransactionService transactionService,
            IWalletService walletService,
            IBudgetService budgetService,
            IConfiguration configuration)
        {
            _goalService = goalService;
            _categoryService = categoryService;
            _transactionService = transactionService;
            _walletService = walletService;
            _budgetService = budgetService;
            _configuration = configuration;
            _history = new List<ChatMessage>();
            _httpClient = new HttpClient();
        }
        public List<ChatMessage> GetHistory()
        {
            return _history;
        }
        public void ClearHistory()
        {
            _history.Clear();
        }
        public async Task<string> SendMessageAsync(string userMessage)
        {
            // 0. Xử lý lệnh Reset/Hủy/Xóa
            if (string.Equals(userMessage, "reset", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(userMessage, "hủy", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(userMessage, "clear", StringComparison.OrdinalIgnoreCase))
            {
                _pendingAction = null;
                _pendingGoalName = null;
                _pendingAmount = 0;
                _history.Clear();
                return "🔄 Đã đặt lại cuộc trò chuyện. Tôi có thể giúp gì cho bạn?";
            }
            // 1. Add user message to history
            _history.Add(new ChatMessage(userMessage, true));
            // 2. Kiểm tra xem có pending action không (user đang trả lời câu hỏi chọn ví)
            if (_pendingAction == "choose_wallet_for_deposit")
            {
                string userId = ExpenseManager.App.Session.CurrentUserSession.CurrentUser?.UserId;
                var allWallets = await _walletService.GetWalletsByUserIdAsync(userId);

                // Tìm ví (So sánh không phân biệt hoa thường)
                var selectedWallet = allWallets.FirstOrDefault(w => w.WalletName.Trim().Equals(userMessage.Trim(), StringComparison.OrdinalIgnoreCase));
                if (selectedWallet != null)
                {
                    // Đã tìm thấy ví, kiểm tra số dư
                    if (selectedWallet.Balance >= _pendingAmount)
                    {
                        var goals = await _goalService.GetUserGoalsAsync(userId);
                        var targetGoal = goals.FirstOrDefault(g => g.GoalName.Equals(_pendingGoalName, StringComparison.OrdinalIgnoreCase));
                        if (targetGoal == null)
                        {
                            _pendingAction = null;
                            return "❌ Đã xảy ra lỗi: Không tìm thấy mục tiêu này nữa. Vui lòng thử lại.";
                        }
                        var depositDto = new GoalDepositDTO
                        {
                            GoalId = targetGoal.GoalId,
                            UserId = userId,
                            WalletId = selectedWallet.WalletId,
                            Amount = _pendingAmount,
                            Note = "Nạp tiền tự động qua AI",
                            Status = "Completed"
                        };
                        await _goalService.DepositToGoalAsync(depositDto);
                        decimal amountDeposited = _pendingAmount;
                        // Reset pending state
                        _pendingAction = null;
                        _pendingGoalName = null;
                        _pendingAmount = 0;
                        string response = $"✅ Đã nạp {amountDeposited:N0} VND vào mục tiêu '{targetGoal.GoalName}' từ ví '{selectedWallet.WalletName}'!";
                        _history.Add(new ChatMessage(response, false));
                        return response;
                    }
                    else
                    {
                        // Tìm thấy ví nhưng không đủ tiền
                        string response = $"⚠️ Ví '{selectedWallet.WalletName}' chỉ còn {selectedWallet.Balance:N0} VND, không đủ để nạp {_pendingAmount:N0} VND.\n👉 Vui lòng chọn ví khác hoặc gõ 'Hủy'.";
                        _history.Add(new ChatMessage(response, false));
                        return response;
                    }
                }
                else
                {
                    // KHÔNG TÌM THẤY VÍ
                    // Kiểm tra xem có phải lệnh mới không (Smart Escape)
                    string lowerMsg = userMessage.ToLower();
                    if (userMessage.Length > 20 ||
                        lowerMsg.StartsWith("nạp") ||
                        lowerMsg.StartsWith("tạo") ||
                        lowerMsg.StartsWith("thêm"))
                    {
                        _pendingAction = null;
                        _pendingGoalName = null;
                        _pendingAmount = 0;
                        // Code sẽ chạy tiếp xuống phần gọi AI để xử lý lệnh mới
                    }
                    else
                    {
                        // Không phải lệnh mới, báo lỗi không tìm thấy ví
                        string availableWallets = string.Join(", ", allWallets.Select(w => w.WalletName));
                        string response = $"❌ Không tìm thấy ví tên '{userMessage}'.\n📋 Các ví hiện có: {availableWallets}.\n👉 Vui lòng nhập đúng tên ví hoặc gõ 'Hủy'.";
                        _history.Add(new ChatMessage(response, false));
                        return response;
                    }
                }
            }
            // 3. Gather Context
            string context = await GetFinancialContextAsync();
            // 4. Construct Prompt with Command Instructions
            var prompt = $"Bạn là trợ lý tài chính trong ứng dụng ExpenseManager. " +
                         $"Dữ liệu hiện tại:\n{context}\n\n" +
                         $"Người dùng: \"{userMessage}\"\n" +
                         $"HƯỚNG DẪN ĐẶC BIỆT (QUAN TRỌNG):\n" +
                         $"Nếu người dùng yêu cầu thực hiện hành động (tạo mục tiêu, tạo ví, nạp tiền), bạn KHÔNG được trả lời bằng lời nói. " +
                         $"Thay vào đó, hãy trả về MỘT chuỗi JSON duy nhất theo định dạng sau:\n" +
                         $"- Tạo mục tiêu: {{ \"action\": \"create_goal\", \"name\": \"Tên mục tiêu\", \"amount\": 500000, \"deadline\": \"yyyy-MM-dd\" }}\n" +
                         $"- Tạo ví: {{ \"action\": \"create_wallet\", \"name\": \"Tên ví\", \"balance\": 1000000 }}\n" +
                         $"- Nạp tiền vào mục tiêu: {{ \"action\": \"deposit_goal\", \"goal_name\": \"Tên mục tiêu\", \"wallet_name\": \"Tên ví (để trống nếu user không chọn)\", \"amount\": 50000 }}\n" +
                         $"- Nạp tiền vào ví: {{ \"action\": \"deposit_wallet\", \"wallet_name\": \"Tên ví\", \"amount\": 100000 }}\n" +
                         $"- Thêm giao dịch: {{ \"action\": \"create_transaction\", \"type\": \"Income/Expense\", \"amount\": 50000, \"category\": \"Tên danh mục\", \"wallet\": \"Tên ví\", \"desc\": \"Mô tả\" }}\n" +
                         $"- Tạo ngân sách: {{ \"action\": \"create_budget\", \"category\": \"Tên danh mục\", \"amount\": 2000000 }}\n" +
                         $"- Xóa mục tiêu: {{ \"action\": \"delete_goal\", \"name\": \"Tên mục tiêu\" }}\n" +
                         $"- Xóa ví: {{ \"action\": \"delete_wallet\", \"name\": \"Tên ví\" }}\n" +
                         $"- Xóa ngân sách: {{ \"action\": \"delete_budget\", \"category\": \"Tên danh mục\" }}\n" +
                         $"- Xem giao dịch: {{ \"action\": \"view_transactions\", \"days\": 7 }}\n" +
                         $"Nếu không phải hành động, hãy trả lời bình thường bằng tiếng Việt ngắn gọn.\n" +
                         $"LƯU Ý: Nếu trả về JSON, chỉ trả về JSON thuần túy, KHÔNG rào đón, KHÔNG giải thích.";
            // 5. Call Groq API
            string aiResponseRaw = await CallGroqApiAsync(prompt);
            string finalResponse = aiResponseRaw;
            
            // 6. Process Command if JSON is detected (Robust extraction)
            int jsonStartIndex = aiResponseRaw.IndexOf('{');
            int jsonEndIndex = aiResponseRaw.LastIndexOf('}');
            
            if (jsonStartIndex >= 0 && jsonEndIndex > jsonStartIndex)
            {
                string potentialJson = aiResponseRaw.Substring(jsonStartIndex, jsonEndIndex - jsonStartIndex + 1);
                try
                {
                    // Validate if it's parseable
                    using (JsonDocument.Parse(potentialJson))
                    {
                        // It's valid JSON, execute it
                        finalResponse = await ProcessAICommandAsync(potentialJson);
                    }
                }
                catch
                {
                    // Not valid JSON, output original text
                    finalResponse = aiResponseRaw;
                }
            }
            // 7. Add AI response to history
            _history.Add(new ChatMessage(finalResponse, false));
            return finalResponse;
        }
        private async Task<string> ProcessAICommandAsync(string jsonResponse)
        {
            using var doc = JsonDocument.Parse(jsonResponse);
            var root = doc.RootElement;
            string action = root.GetProperty("action").GetString();
            string userId = ExpenseManager.App.Session.CurrentUserSession.CurrentUser?.UserId;
            if (string.IsNullOrEmpty(userId)) return "Lỗi: Không tìm thấy người dùng.";
            switch (action)
            {
                case "create_goal":
                    string deadlineStr = root.GetProperty("deadline").GetString();
                    DateTime completionDate;

                    // Nếu AI trả về format thay vì ngày thực, dùng ngày mặc định
                    if (!DateTime.TryParse(deadlineStr, out completionDate))
                    {
                        completionDate = DateTime.Now.AddMonths(1); // Mặc định 1 tháng sau
                    }

                    var goalDto = new CreateGoalDTO
                    {
                        UserId = userId,
                        GoalName = root.GetProperty("name").GetString(),
                        TargetAmount = root.GetProperty("amount").GetDecimal(),
                        CompletionDate = completionDate
                    };
                    await _goalService.CreateGoalAsync(goalDto);
                    return $"✅ Đã tạo mục tiêu '{goalDto.GoalName}' thành công!";
                case "create_wallet":
                    var allWalletsCheck = await _walletService.GetWalletsByUserIdAsync(userId);
                    string newWalletName = root.GetProperty("name").GetString();
                    if (allWalletsCheck.Any(w => w.WalletName.Equals(newWalletName, StringComparison.OrdinalIgnoreCase)))
                    {
                        return $"❌ Ví '{newWalletName}' đã tồn tại. Vui lòng đặt tên khác.";
                    }
                    var wallet = new Wallet
                    {
                        UserId = userId,
                        WalletName = newWalletName,
                        Balance = root.GetProperty("balance").GetDecimal(),
                        InitialBalance = root.GetProperty("balance").GetDecimal(),
                        WalletType = "General",
                        Icon = "wallet",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    await _walletService.CreateWalletAsync(wallet);
                    return $"✅ Đã tạo ví '{wallet.WalletName}' thành công!";
                case "deposit_goal":
                    string goalName = root.GetProperty("goal_name").GetString();
                    string walletNameRaw = root.TryGetProperty("wallet_name", out var wElem) ? wElem.GetString() : null;
                    decimal amount = root.GetProperty("amount").GetDecimal();
                    var goals = await _goalService.GetUserGoalsAsync(userId);
                    var targetGoal = goals.FirstOrDefault(g => g.GoalName.Equals(goalName, StringComparison.OrdinalIgnoreCase));
                    if (targetGoal == null) return $"❌ Không tìm thấy mục tiêu tên '{goalName}'.";
                    var allWallets = await _walletService.GetWalletsByUserIdAsync(userId);
                    Wallet selectedWallet = null;
                    string autoMsg = "";
                    if (!string.IsNullOrEmpty(walletNameRaw))
                    {
                        selectedWallet = allWallets.FirstOrDefault(w => w.WalletName.Equals(walletNameRaw, StringComparison.OrdinalIgnoreCase));
                        if (selectedWallet == null)
                        {
                            var existingNames = string.Join(", ", allWallets.Select(w => w.WalletName));
                            return $"❌ Không tìm thấy ví '{walletNameRaw}'. Các ví hiện có: {existingNames}. Vui lòng chọn lại.";
                        }
                        if (selectedWallet.Balance < amount)
                        {
                            var otherAffordable = allWallets.Where(w => w.Balance >= amount).Select(w => w.WalletName).ToList();
                            string suggestion = otherAffordable.Any()
                                ? $"Các ví đủ tiền: {string.Join(", ", otherAffordable)}"
                                : "Không có ví nào đủ tiền.";
                            return $"⚠️ Ví '{selectedWallet.WalletName}' không đủ tiền (Dư: {selectedWallet.Balance:N0}). {suggestion}";
                        }
                    }
                    else
                    {
                        var affordableWallets = allWallets.Where(w => w.Balance >= amount).ToList();
                        if (!affordableWallets.Any())
                        {
                            return $"❌ Bạn muốn nạp {amount:N0} nhưng không có ví nào đủ số dư.";
                        }
                        else if (affordableWallets.Count == 1)
                        {
                            selectedWallet = affordableWallets.First();
                            autoMsg = $"(Tự động chọn ví '{selectedWallet.WalletName}') ";
                        }
                        else
                        {
                            _pendingAction = "choose_wallet_for_deposit";
                            _pendingGoalName = goalName;
                            _pendingAmount = amount;
                            string listW = string.Join(", ", affordableWallets.Select(w => w.WalletName));
                            return $"❓ Bạn muốn dùng ví nào? Có nhiều ví đủ tiền: {listW}.\n(Vui lòng trả lời tên ví)";
                        }
                    }
                    var depositDto = new GoalDepositDTO
                    {
                        GoalId = targetGoal.GoalId,
                        UserId = userId,
                        WalletId = selectedWallet.WalletId,
                        Amount = amount,
                        Note = "Nạp tiền tự động qua AI",
                        Status = "Completed"
                    };
                    await _goalService.DepositToGoalAsync(depositDto);
                    return $"✅ {autoMsg}Đã nạp {amount:N0} VND vào mục tiêu '{goalName}' từ ví '{selectedWallet.WalletName}'!";
                case "deposit_wallet":
                    string targetWalletName = root.GetProperty("wallet_name").GetString();
                    decimal depositAmount = root.GetProperty("amount").GetDecimal();
                    var userWallets = await _walletService.GetWalletsByUserIdAsync(userId);
                    var targetWallet = userWallets.FirstOrDefault(w => w.WalletName.Equals(targetWalletName, StringComparison.OrdinalIgnoreCase));
                    if (targetWallet == null) return $"❌ Không tìm thấy ví tên '{targetWalletName}'.";
                    targetWallet.Balance += depositAmount;
                    targetWallet.UpdatedAt = DateTime.Now;
                    try
                    {
                        await _walletService.UpdateWalletAsync(targetWallet);
                        return $"✅ Đã nạp {depositAmount:N0} VND vào ví '{targetWalletName}'. Số dư mới: {targetWallet.Balance:N0} VND.";
                    }
                    catch (Exception ex)
                    {
                        return $"❌ Lỗi khi nạp tiền: {ex.Message}";
                    }
                case "create_transaction":
                    string transType = root.GetProperty("type").GetString(); // "Income" or "Expense"
                    decimal transAmount = root.GetProperty("amount").GetDecimal();
                    string transCategoryName = root.GetProperty("category").GetString();
                    string transWalletName = root.GetProperty("wallet").GetString();
                    string transDesc = root.GetProperty("desc").GetString();

                    var walletsArg = await _walletService.GetWalletsByUserIdAsync(userId);
                    var walletTrans = walletsArg.FirstOrDefault(w => w.WalletName.Equals(transWalletName, StringComparison.OrdinalIgnoreCase));
                    if (walletTrans == null) return $"❌ Không tìm thấy ví '{transWalletName}'.";

                    // Simple category lookup (improve if needed by fetching from DB)
                    var categories = await _categoryService.GetCategoriesByUserIdAsync(userId);
                    var categoryTrans = categories.FirstOrDefault(c => c.CategoryName.Equals(transCategoryName, StringComparison.OrdinalIgnoreCase));
                    
                    // If category not found, try to map generic names or default
                    if (categoryTrans == null)
                    {
                        // Fallback or create? For now just report error or pick first
                        return $"❌ Không tìm thấy danh mục '{transCategoryName}'. Vui lòng tạo danh mục trước.";
                    }

                    var transaction = new Transaction
                    {
                        UserId = userId,
                        WalletId = walletTrans.WalletId,
                        CategoryId = categoryTrans.CategoryId,
                        Type = transType,
                        Amount = transAmount,
                        TransactionDate = DateTime.Now,
                        Description = transDesc,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    await _transactionService.AddTransactionAsync(transaction);
                    
                    // Update wallet balance
                    if (transType.Equals("Income", StringComparison.OrdinalIgnoreCase))
                        walletTrans.Balance += transAmount;
                    else
                        walletTrans.Balance -= transAmount;
                    
                    await _walletService.UpdateWalletAsync(walletTrans);

                    return $"✅ Đã thêm giao dịch: {transType} {transAmount:N0} VND ({transDesc}) vào ví {walletTrans.WalletName}.";

                case "create_budget":
                    string budCatName = root.GetProperty("category").GetString();
                    decimal budAmount = root.GetProperty("amount").GetDecimal();

                    var cats = await _categoryService.GetCategoriesByUserIdAsync(userId);
                    var budCat = cats.FirstOrDefault(c => c.CategoryName.Equals(budCatName, StringComparison.OrdinalIgnoreCase));
                    if (budCat == null) return $"❌ Không tìm thấy danh mục '{budCatName}'.";

                    var budgetDto = new BudgetCreateDto
                    {
                        CategoryId = budCat.CategoryId,
                        BudgetAmount = budAmount,
                        StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                        EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)),
                        IsRecurring = false
                    };

                    try
                    {
                        await _budgetService.CreateBudgetAsync(budgetDto, userId);
                        return $"✅ Đã tạo ngân sách {budAmount:N0} VND cho danh mục '{budCat.CategoryName}' tháng này.";
                    }
                    catch (Exception ex)
                    {
                        return $"❌ Lỗi tạo ngân sách: {ex.Message}";
                    }

                case "delete_goal":
                    string delGoalName = root.GetProperty("name").GetString();
                    var goalsToDelete = await _goalService.GetUserGoalsAsync(userId);
                    var goalToDelete = goalsToDelete.FirstOrDefault(g => g.GoalName.Equals(delGoalName, StringComparison.OrdinalIgnoreCase));
                    if (goalToDelete == null) return $"❌ Không tìm thấy mục tiêu '{delGoalName}'.";
                    await _goalService.DeleteGoalAsync(goalToDelete.GoalId);
                    return $"✅ Đã xóa mục tiêu '{delGoalName}'.";



                case "delete_wallet":
                    string delWalletName = root.GetProperty("name").GetString();
                    var walletsToDelete = await _walletService.GetWalletsByUserIdAsync(userId);
                    var walletToDelete = walletsToDelete.FirstOrDefault(w => w.WalletName.Equals(delWalletName, StringComparison.OrdinalIgnoreCase));
                    if (walletToDelete == null) return $"❌ Không tìm thấy ví '{delWalletName}'.";
                    await _walletService.DeleteWalletAsync(walletToDelete.WalletId);
                    return $"✅ Đã xóa ví '{delWalletName}'.";

                case "delete_budget":
                    string delBudCat = root.GetProperty("category").GetString();
                    var budgetsToDelete = await _budgetService.GetUserBudgetSummariesAsync(userId);
                    var budgetToDelete = budgetsToDelete.FirstOrDefault(b => b.CategoryName.Equals(delBudCat, StringComparison.OrdinalIgnoreCase));
                    if (budgetToDelete == null) return $"❌ Không tìm thấy ngân sách cho danh mục '{delBudCat}'.";
                    await _budgetService.DeleteBudgetAsync(budgetToDelete.BudgetId, userId);
                    return $"✅ Đã xóa ngân sách cho danh mục '{delBudCat}'.";

                case "view_transactions":
                    int days = root.TryGetProperty("days", out var daysElem) ? daysElem.GetInt32() : 7;
                    var transactions = await _transactionService.GetRecentTransactionsAsync(userId, days);
                    
                    if (transactions == null || !transactions.Any())
                        return $"📭 Không có giao dịch nào trong {days} ngày qua.";

                    var sbTrans = new StringBuilder();
                    sbTrans.AppendLine($"📋 **Giao dịch {days} ngày gần đây:**");
                    foreach (var t in transactions)
                    {
                        string sign = t.Type == "Income" ? "+" : "-";
                        sbTrans.AppendLine($"- {t.TransactionDate:dd/MM} | {t.Category.CategoryName}: {sign}{t.Amount:N0}đ ({t.Description})");
                    }
                    return sbTrans.ToString();

                default:
                    return "⚠️ AI gửi lệnh không xác định.";
            }
        }
        private async Task<string> GetFinancialContextAsync()
        {
            var sb = new StringBuilder();
            try
            {
                string userId = ExpenseManager.App.Session.CurrentUserSession.CurrentUser?.UserId ?? "";
                if (string.IsNullOrEmpty(userId)) return "Không tìm thấy thông tin người dùng.";
                
                sb.AppendLine($"Hôm nay là ngày: {DateTime.Now:dd/MM/yyyy}");

                // Goals
                var goals = await _goalService.GetUserGoalsAsync(userId);
                sb.AppendLine("--- MỤC TIÊU (GOALS) ---");
                foreach (var g in goals)
                {
                    string status = g.CurrentAmount >= g.TargetAmount ? "Đã hoàn thành" : "Đang thực hiện";
                    sb.AppendLine($"- {g.GoalName}: {g.CurrentAmount}/{g.TargetAmount} ({status}) (Hạn: {g.CompletionDate:dd/MM/yyyy})");
                }
                // Wallets
                var wallets = await _walletService.GetWalletsByUserIdAsync(userId);
                sb.AppendLine("\n--- VÍ (WALLETS) ---");
                foreach (var w in wallets)
                {
                    sb.AppendLine($"- {w.WalletName}: {w.Balance} VND");
                }

                // Budget Alerts
                var budgets = await _budgetService.GetUserBudgetSummariesAsync(userId);
                sb.AppendLine("\n--- NGÂN SÁCH (BUDGETS) ---");
                foreach (var b in budgets)
                {
                    string warning = b.PercentageUsed >= 100 ? "🔴 VƯỢT QUÁ!" : 
                                     b.PercentageUsed >= 80 ? "🟡 Sắp hết" : "🟢 OK";
                    sb.AppendLine($"- {b.CategoryName}: {b.SpentAmount:N0}/{b.BudgetAmount:N0} ({b.PercentageUsed}%) {warning}");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"Lỗi khi lấy dữ liệu: {ex.Message}");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Gọi Groq API (OpenAI-compatible format)
        /// </summary>
        private async Task<string> CallGroqApiAsync(string prompt)
        {
            try
            {
                var apiKey = _configuration["Groq:ApiKey"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    return "❌ Lỗi: Không tìm thấy Groq API key trong appsettings.json. Vui lòng thêm key vào mục 'Groq:ApiKey'.";
                }
                // Groq sử dụng format OpenAI-compatible
                var requestBody = new
                {
                    model = MODEL,
                    messages = new[]
                    {
                        new { role = "system", content = "Bạn là trợ lý tài chính thông minh, trả lời bằng tiếng Việt." },
                        new { role = "user", content = prompt }
                    },
                    temperature = 0.7,
                    max_tokens = 1024
                };
                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // Thêm Authorization header
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                var response = await _httpClient.PostAsync(API_URL, content);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return $"Lỗi API Groq ({response.StatusCode}): {errorContent}";
                }
                var responseString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(responseString);
                var root = doc.RootElement;
                // Parse response theo format OpenAI
                if (root.TryGetProperty("choices", out var choices) && choices.GetArrayLength() > 0)
                {
                    var firstChoice = choices[0];
                    if (firstChoice.TryGetProperty("message", out var message) &&
                        message.TryGetProperty("content", out var contentElem))
                    {
                        string text = contentElem.GetString();
                        // Clean up JSON markdown if present (```json ... ```)
                        text = text.Replace("```json", "").Replace("```", "").Trim();
                        return text;
                    }
                }
                return "Không nhận được phản hồi từ AI.";
            }
            catch (Exception ex)
            {
                return $"Lỗi kết nối Groq AI: {ex.Message}";
            }
        }
    }
}