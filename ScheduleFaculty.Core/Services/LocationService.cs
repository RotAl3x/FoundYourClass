using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ScheduleFaculty.Core.Database;
using ScheduleFaculty.Core.Entities;
using ScheduleFaculty.Core.Services.Abstractions;
using ScheduleFaculty.Core.Utils;

namespace ScheduleFaculty.Core.Services;

public class LocationService : ILocationService
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

    public async Task<ActionResponse<Location>> CreateLocation(string name, decimal latitude, decimal longitude, string videoPath)
    {
        var response = new ActionResponse<Location>();

        var dbLocation = await _dbContext.Location.AddAsync(new Location
        {
            Name = name,
            Latitude = latitude,
            Longitude = longitude,
            VideoPath = videoPath,   
        });
        await _dbContext.SaveChangesAsync();


        response.Item = dbLocation.Entity;
        return response;
    }

    public async Task<ActionResponse<string>> SaveFile(IFormFile file)
    {
        var response = new ActionResponse<string>();
        string filename = "";
        try
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            filename = DateTime.Now.Ticks.ToString() + extension;
            var filepath = "D:\\Upload\\Files";

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            var exactpath = Path.Combine("D:\\Upload\\Files", filename);
            using (var stream = new FileStream(exactpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            response.Item = exactpath;
            return response;
        }
        catch (Exception ex)
        {
            response.AddError("Unable to upload");
            return response;
        }
    }
}