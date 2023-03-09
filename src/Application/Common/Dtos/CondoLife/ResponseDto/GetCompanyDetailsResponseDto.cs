using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetCompanyDetailsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameEn { get; set; }
    public string Logo { get; set; }
    public string Title { get; set; }
    public string TaxAdministration { get; set; }
    public string TaxNo { get; set; }
    public string ResponsibleName { get; set; }
    public string PhoneNumber { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public bool IsInside { get; set; }
}
