using System;

namespace ExpenseManager.App.Models.DTOs
{
 
    /// DTO chứa dữ liệu cho các thẻ KPI trên Dashboard
    public class KPIStatsDTO
    {
        //USER KPI
        /// Tổng số người dùng trong hệ thống
        public int TotalUsers { get; set; }
     
        /// Số lượng users mới được tạo trong tháng hiện tại
        public int NewUsersThisMonth { get; set; }

        /// Tỉ lệ tăng trưởng users so với tháng trước (%)
        public decimal UserGrowthRate { get; set; }

        //TRANSACTION KPI     
        /// Tổng số giao dịch trong hệ thống
        public int TotalTrans { get; set; }

        /// Số lượng transactions mới được tạo trong tháng hiện tại
        public int NewTransThisMonth { get; set; }
     
        /// Tỉ lệ tăng trưởng transactions so với tháng trước (%)
        public decimal TransGrowthRate { get; set; }
        //TICKET KPI     
        /// Tổng số tickets trong hệ thống
        public int TotalTickets { get; set; }
     
        /// Số lượng tickets đang ở trạng thái Pending
 
        public int PendingTickets { get; set; }
        public int OpenTickets { get; set; }     
        public int ResolvedTickets { get; set; }
    }
}