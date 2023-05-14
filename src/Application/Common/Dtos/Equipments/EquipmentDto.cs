namespace CleanArchitecture.Application.Common.Dtos.Equipments;

public class EquipmentDto
{
    public string Name { get; set; }
    public bool IsNoise { get; set; }
    public bool IsHeat { get; set; }
    public bool IsTemp { get; set; }
}