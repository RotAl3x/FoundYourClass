using Microsoft.EntityFrameworkCore;
using ScheduleFaculty.Core.Database;
using ScheduleFaculty.Core.Entities;
using ScheduleFaculty.Core.Services.Abstractions;
using ScheduleFaculty.Core.Utils;

namespace ScheduleFaculty.Core.Services;

public class LocationService:ILocationService
{
    
    private readonly ApplicationDbContext _dbContext;

    public LocationService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ActionResponse<List<Location>>> GetAll()
    {
        var locations = await _dbContext.Location.ToListAsync();
        
        var response = new ActionResponse<List<Location>>();
        response.Item = locations;
        return response;
    }
}