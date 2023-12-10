namespace ScheduleFaculty.Api.DTOs;

public class HourDTO
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public string StartHour { get; set; }
    public string EndHour { get; set; }
    public List<DateTime> DatesToHour { get; set; }
}