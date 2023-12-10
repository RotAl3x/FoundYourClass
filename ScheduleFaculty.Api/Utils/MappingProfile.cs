using AutoMapper;
using ScheduleFaculty.Api.DTOs;
using ScheduleFaculty.Core.Entities;

namespace ScheduleFaculty.API.Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hour, HourResponseDTO>().ReverseMap();
        CreateMap<DatesToHour, DatesToHourDTO>().ReverseMap();

    }
}