using System;

namespace ExpenseManager.App.Models.DTOs
{
    /// <summary>
    /// DTO chứa dữ liệu cho các thẻ KPI trên Dashboard
    /// </summary>
    public class KPIStatsDTO
    {
        // ===== USER KPI =====
        /// <summary>
        /// Tổng số người dùng trong hệ thống
        /// </summary>
        public int TotalUsers { get; set; }

        /// <summary>
        /// Số lượng users mới được tạo trong tháng hiện tại
        /// </summary>
        public int NewUsersThisMonth { get; set; }

        /// <summary>
        /// Tỉ lệ tăng trưởng users so với tháng trước (%)
        /// </summary>
        public decimal UserGrowthRate { get; set; }

        // ===== TRANSACTION KPI =====
        /// <summary>
        /// Tổng số giao dịch trong hệ thống
        /// </summary>
        public int TotalTrans { get; set; }

        /// <summary>
        /// Số lượng transactions mới được tạo trong tháng hiện tại
        /// </summary>
        public int NewTransThisMonth { get; set; }

        /// <summary>
        /// Tỉ lệ tăng trưởng transactions so với tháng trước (%)
        /// </summary>
        public decimal TransGrowthRate { get; set; }

        // ===== TICKET KPI =====
        /// <summary>
        /// Tổng số tickets trong hệ thống
        /// </summary>
        public int TotalTickets { get; set; }

        /// <summary>
        /// Số lượng tickets đang ở trạng thái Pending
        /// </summary>
        public int PendingTickets { get; set; }
        public int OpenTickets { get; set; }     
        public int ResolvedTickets { get; set; }
    }
}