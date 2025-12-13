using ExpenseManager.App.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public interface IAIChatService
    {
        Task<string> SendMessageAsync(string userMessage);
        List<ChatMessage> GetHistory();
        void ClearHistory();
    }
}
