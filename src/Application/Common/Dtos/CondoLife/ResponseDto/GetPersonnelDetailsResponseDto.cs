using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetPersonnelDetailsResponseDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string CountryPhoneCode { get; set; }
    public int SupervisorId { get; set; }

    public string PhoneNumber { get; set; }
    public string HomePhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public int? BirthPlaceId { get; set; }
    public string RelativePhoneNumber { get; set; }
    public int? RelativeDegree { get; set; }
    public int? CityId { get; set; }
    public string CitizenNumber { get; set; }
    public string Email { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public int? MaxVehicleCount { get; set; }
    public string ProfilePictureUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public Guid EmployeeGateId { get; set; }
    public string GeneratedPassword { get; set; }
    public int? UnitId { get; set; }
    public bool? KvkkPermissionAccept { get; set; }
    public double RatingAverage { get; set; }
    public double Salary { get; set; }
    public int ProfileOccupancyPercentage { get; set; }

    public int WeeklyWorkTime { get; set; }
    public int YearlyPermit { get; set; }
    public int ChildCount { get; set; }
    public bool isWifeWork { get; set; }
    public bool isMarried { get; set; }
}
