namespace Application.Dtos.OrderDtos;

public class SalesByMonthDto
{
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal TotalSales { get; set; }
}
