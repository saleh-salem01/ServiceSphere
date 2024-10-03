using AutoMapper;
using PlatformServices.Dtos;
using PlatformServices.Models;

namespace PlatformServices.Profile;

public class PlatformsProfiles :AutoMapper.Profile { 
    public void Platformsprofile()
    {
        //source --> target 
        CreateMap<Platform,PlatformReadDto>();
        CreateMap<PlatformCreateDto,Platform>();
    }
}
