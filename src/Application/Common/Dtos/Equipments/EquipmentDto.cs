using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.Equipments;

public class EquipmentDto
{
    public int Id { get; set; }
    public LanguageString Name { get; set; }
    public bool IsNoise { get; set; }
    public bool IsHeat { get; set; }
    public bool IsHidden { get; set; }
}