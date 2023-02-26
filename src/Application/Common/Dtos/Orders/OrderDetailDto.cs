using CleanArchitecture.Application.Common.Dtos.POI.Transfer.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.Transactions;
using CleanArchitecture.Domain.Enums.POI;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class OrderDetailDto
{
    public TransactionStatus Status { get; set; }
    public string ReservationNo { get; set; }
    public string CustomerPhoto { get; set; }
    public string CustomerSegment { get; set; }
    public string CustomerEmail { get; set; }
    public string Nationality { get; set; }
    public string CustomerId { get; set; }
    public string StartPoint { get; set; }
    public string StartPointDescription { get; set; }
    public string StartPointDetail { get; set; }
    public string EndPoint { get; set; }
    public string EndPointDescription { get; set; }
    public string EndPointDetail { get; set; }
    public LvtdDto CarDetail { get; set; } 
    public string CitizenNumber { get; set; }
    public string TransferNote { get; set; }
    public DateTime? ReservationDate { get; set; }

    public List<ExtraDto> Extras { get; set; }
}