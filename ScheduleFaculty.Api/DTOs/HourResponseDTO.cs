using ScheduleFaculty.Core.Entities;

namespace ScheduleFaculty.Api.DTOs;

public class HourResponseDTO
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Location Location { get; set; }
    public string StartHour { get; set; }
    public string EndHour { get; set; }
    public ICollection<DatesToHourDTO> DatesToHour { get; set; }
}