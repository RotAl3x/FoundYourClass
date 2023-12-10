using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScheduleFaculty.Core.Entities;
using ScheduleFaculty.Core.Services.Abstractions;

namespace ScheduleFaculty.Api.ApiControllers;

[ApiController]
[Route("/api/location")]

public class LocationController: ControllerBase
{
    
    private readonly ILocationService _locationService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public LocationController(ILocationService locationService, UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _locationService=locationService;
        _userManager = userManager;
        _mapper = mapper;
    }
    
    [HttpGet("getAll")]
    public async Task<ActionResult> GetAll()
    {
        var locations = await _locationService.GetAll();
        if (locations.HasErrors())
        {
            return BadRequest(locations.Errors);
        }

        return Ok(locations.Item);
    }
}