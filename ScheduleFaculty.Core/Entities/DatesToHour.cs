using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ScheduleFaculty.Core.Entities;

public class DatesToHour
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public bool SpecialEvent { get; set; }
    [ForeignKey(("User"))]
    public string UserId { get; set; }
    [JsonIgnore]
    public ApplicationUser User { get; set; }
    [ForeignKey(("Hour"))]
    public Guid HourId { get; set; }
    public Hour Hour { get; set; }
}