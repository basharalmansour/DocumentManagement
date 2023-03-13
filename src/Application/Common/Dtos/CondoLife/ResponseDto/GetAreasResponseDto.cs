using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetAreasResponseDto
{
    public int Id { get; set; }
    public Guid? CondoZoneId { get; set; }
    public Guid? CondoBlockId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int AreaTypeId { get; set; }
    public Guid? CondoBlockFloorId { get; set; }
    public int ParentUnitId { get; set; }
    public int ParentAreaId { get; set; }

    public int POIId { get; set; }
    public int ContractNo { get; set; }
    public int DoorNo { get; set; }
    public string Tel { get; set; }
    public string Website { get; set; }
    public string Note { get; set; }
    public string ImageURL { get; set; }
    public int SquareM2Net { get; set; }
    public int SquareM2Gross { get; set; }
    public int CarMaxCount { get; set; }
    public int VisitorMaxCount { get; set; }
    public bool IsQR { get; set; }
    public bool IsRent { get; set; }
    public bool IsActive { get; set; }
}
