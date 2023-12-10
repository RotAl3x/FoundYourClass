using ScheduleFaculty.Core.Entities;

namespace ScheduleFaculty.Api.DTOs;

public class DatesToHourDTO
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public bool SpecialEvent { get; set; }
    public string UserId { get; set; }
    public Guid HourId { get; set; }
}