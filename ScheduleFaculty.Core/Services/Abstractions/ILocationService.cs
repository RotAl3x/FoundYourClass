using ScheduleFaculty.Core.Entities;
using ScheduleFaculty.Core.Utils;

namespace ScheduleFaculty.Core.Services.Abstractions;

public interface ILocationService
{
    Task<ActionResponse<List<Location>>> GetAll();
}