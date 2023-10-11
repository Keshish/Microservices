using AutoMapper;
using PlatformService.Models;

namespace PlatformService.Dtos.AutoMapper
{
    public class PlatformProfile:Profile
    {
        public PlatformProfile()
        {
            //Source => Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}
