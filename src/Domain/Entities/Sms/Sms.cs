using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Sms;

public class Sms : ISoftDeletable, IEntity<int>
{
    public int Id { get; set; }
    public string? IntegrationUserId { get; set; }
    public string Message { get; set; }
    public string IntegrationName { get; set; }
    public string PhoneNumber { get; set; }
    public OtpMessageStatus MessageStatus { get; set; }
    public string Token { get; set; }
    public TimeSpan Duration { get; set; }  
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime CreatedDateTime { get; set; }
}
