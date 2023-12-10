namespace ScheduleFaculty.Core.Entities;

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string VideoPath { get; set; }
}