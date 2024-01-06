using Microsoft.AspNetCore.Http;
using ScheduleFaculty.Core.Entities;
using ScheduleFaculty.Core.Utils;

namespace ScheduleFaculty.Core.Services.Abstractions;

public interface ILocationService
{
    Task<ActionResponse<List<Location>>> GetAll();
    Task<ActionResponse<string>> SaveFile(IFormFile file);
    Task<ActionResponse<Location>> CreateLocation(string name, decimal latitude, decimal longitude, string videoPath);
} 