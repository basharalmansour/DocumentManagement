using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Enums.CondoLifeEnums;

public enum UserType
{
    [Display(Name = "Yaşayan")] Living = 0,

    [Display(Name = "Çalışan")] Employee = 1,

    [Display(Name = "AvmUser")] AvmUser = 3,

    [Display(Name = "UnitAttendance")] UnitAttendance = 4,

    [Display(Name = "UnitOwner")]
    UnitOwner = 5,

    [Display(Name = "AVMLiving")]
    AVMLiving = 6,
    /// <summary>
    /// Indicates all types of Living, Employee and Avm users
    /// </summary>
    [Display(Name = "All")] All = 255,
    [Display(Name = "CondoAdmin")] CondoAdmin = 7,
    [Display(Name = "TesisAdmin")] TesisAdmin = 8
}