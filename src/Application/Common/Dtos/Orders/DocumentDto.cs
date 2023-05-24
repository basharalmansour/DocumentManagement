using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Orders;

public class DocumentDto
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public decimal FileSize { get; set; }
    public string FilePath { get; set; }
    public int DocumentTemplateId { get; set; }
    public string DocumentTemplateName { get; set; } //
}