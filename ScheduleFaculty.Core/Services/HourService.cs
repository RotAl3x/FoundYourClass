using Microsoft.EntityFrameworkCore;
using ScheduleFaculty.Core.Database;
using ScheduleFaculty.Core.Entities;
using ScheduleFaculty.Core.Services.Abstractions;
using ScheduleFaculty.Core.Utils;

namespace ScheduleFaculty.Core.Services;

public class HourService: IHourService
{

    private readonly ApplicationDbContext _dbContext;

    public HourService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ActionResponse<Hour>> GetHourById(Guid id)
    {
        var response = new ActionResponse<Hour>();
        var hour = await _dbContext.Hour.FirstOrDefaultAsync(h => h.Id == id);

        response.Item = hour;
        return response;
    }

    public async  Task<ActionResponse<List<Hour>>> GetAllHoursByUserId(string userId)
    {
        var response = new ActionResponse<List<Hour>>();
        var hour = await _dbContext.Hour.Include(h=>h.Location).Include(h => h.DatesToHour).Where(h=>h.DatesToHour.Any(d=>d.UserId==userId)).ToListAsync();


        response.Item = hour;
        return response;
    }

    public Task<ActionResponse<List<DatesToHour>>> GetAllHoursByUserIdWithSpecialEvents(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ActionResponse<Hour>> CreateHour(string userId, Guid locationId, string startHour, string endHour, string courseName, List<DateTime> dates)
    {
        var response = new ActionResponse<Hour>();

        var datesToHour = new List<DatesToHour>();
        
        
        var dbHour = await _dbContext.Hour.AddAsync(new Hour
        {
            LocationId = locationId,
            StartHour = startHour,
            EndHour = endHour,
            CourseName = courseName
        });
        await _dbContext.SaveChangesAsync();

        foreach (var date in dates)
        {
            datesToHour.Add(new DatesToHour
            {
                Date = date,
                SpecialEvent = false,
                UserId = userId,
                HourId = dbHour.Entity.Id,
            });
        }

        await _dbContext.DatesToHours.AddRangeAsync(datesToHour);
        await _dbContext.SaveChangesAsync();

        response.Item = dbHour.Entity;
        return response;
    }

    public Task<ActionResponse<Hour>> EditHour(Guid id, string userId, Guid locationId, string startHour, string endHour, string courseName, List<DateTime> dates)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResponse<Hour>> DeleteHour(Guid id)
    {
        throw new NotImplementedException();
    }
}