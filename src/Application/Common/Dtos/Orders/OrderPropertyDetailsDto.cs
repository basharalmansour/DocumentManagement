namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class OrderPropertyDetailsDto
{
    public string TransactionNo { get; set; }
    public string ServiceName { get; set; }
    public DateTime TransactionDate { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public decimal Price { get; set; }

    public OrderDetailDto Detail { get; set; }
}