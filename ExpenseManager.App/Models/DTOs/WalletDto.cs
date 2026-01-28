namespace ExpenseManager.App.Models.DTOs
{
    /// DTO cho Wallet dùng trong Analytics và các chức năng khác
    public class WalletDto
    {
        public int WalletID { get; set; }
        public string WalletName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string WalletType { get; set; } = string.Empty;
    }
}