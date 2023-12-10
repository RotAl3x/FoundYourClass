using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScheduleFaculty.Api.DTOs;
using ScheduleFaculty.Core.Entities;
using ScheduleFaculty.Core.Services.Abstractions;

namespace ScheduleFaculty.Api.ApiControllers;


[ApiController]
[Route("/api/hour")]
public class HourController : ControllerBase
{
    private readonly IHourService _hourService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public HourController(IHourService hourServiceRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _hourService = hourServiceRepository;
        _userManager = userManager;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetHourById([FromRoute] Guid id)
    {
        var hour = await _hourService.GetHourById(id);
        if (hour.HasErrors())
        {
            return BadRequest(hour.Errors);
        }

        var response = _mapper.Map<HourResponseDTO>(hour.Item);

        return Ok(response);
    }
    [HttpGet("/api/hour/userId")]
    [Authorize(Roles = "USER",AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> GetHourByUserId()
    {
        var user = await _userManager.GetUserAsync(User);
        var hour = await _hourService.GetAllHoursByUserId(user.Id);
        if (hour.HasErrors())
        {
            return BadRequest(hour.Errors);
        }

        var response = _mapper.Map<List<HourResponseDTO>>(hour.Item);

        return Ok(response);
    }

    [HttpPost]
    [Authorize(Roles = "USER",AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> CreateHour([FromBody] HourDTO hourDto)
    {
        var user = await _userManager.GetUserAsync(User);

        // var hour = await _hourService.CreateHour(user.Id, hourDto.LocationId, hourDto.StartHour, hourDto.EndHour,
        //     hourDto.Dates);
        var hour = await _hourService.CreateHour(user.Id, hourDto.LocationId, hourDto.StartHour, hourDto.EndHour, hourDto.CourseName,
            hourDto.DatesToHour);
        if (hour.HasErrors())
        {
            return BadRequest(hour.Errors);
        }

        return Ok(hour.Item);
    }
}