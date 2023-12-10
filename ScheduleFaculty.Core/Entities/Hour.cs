using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ScheduleFaculty.Core.Entities;

public class Hour
{
    public Guid Id { get; set; }
    [ForeignKey(("Location"))]
    public Guid LocationId { get; set; }
    public Location Location { get; set; }
    public string StartHour { get; set; }
    public string EndHour { get; set; }
    
    public string CourseName { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<DatesToHour> DatesToHour { get; set; }
    
}