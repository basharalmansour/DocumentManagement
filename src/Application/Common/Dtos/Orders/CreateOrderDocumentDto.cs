using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Common.Dtos.Orders;
public class CreateOrderDocumentDto
{
    public int DocumentId { get; set; }
    public IFormFile File { get; set; }
    public FileStatus FileStatus { get; set; }
}
