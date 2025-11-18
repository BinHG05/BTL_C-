namespace ExpenseManager.App.Models.DTOs
{
    /// <summary>
    /// DTO chứa dữ liệu cho từng điểm trên biểu đồ
    /// </summary>
    public class ChartDataPointDTO
    {
        /// <summary>
        /// Nhãn hiển thị trên trục X (ngày, tháng, hoặc năm)
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// Giá trị số lượng tương ứng với nhãn (trục Y)
        /// </summary>
        public float Value { get; set; }
    }
}