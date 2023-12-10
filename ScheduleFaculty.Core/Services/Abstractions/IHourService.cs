using ScheduleFaculty.Core.Entities;
using ScheduleFaculty.Core.Utils;

namespace ScheduleFaculty.Core.Services.Abstractions;

public interface IHourService
{
    Task<ActionResponse<Hour>> GetHourById(Guid id);
    Task<ActionResponse<List<Hour>>> GetAllHoursByUserId(string userId);
    Task<ActionResponse<List<DatesToHour>>> GetAllHoursByUserIdWithSpecialEvents(string userId);
    Task<ActionResponse<Hour>> CreateHour(string userId, Guid locationId, string startHour, string endHour, List<DateTime> dates);
    Task<ActionResponse<Hour>> EditHour(Guid id,string userId, Guid locationId, string startHour, string endHour, List<DateTime> dates);
    Task<ActionResponse<Hour>> DeleteHour(Guid id);
}