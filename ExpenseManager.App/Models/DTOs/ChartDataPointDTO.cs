namespace ExpenseManager.App.Models.DTOs
{
    /// DTO chứa dữ liệu cho từng điểm trên biểu đồ
    public class ChartDataPointDTO
    {
        /// Nhãn hiển thị trên trục X (ngày, tháng, hoặc năm)
        public string Label { get; set; } = string.Empty;

        /// Giá trị số lượng tương ứng với nhãn (trục Y)
        public float Value { get; set; }
    }
}