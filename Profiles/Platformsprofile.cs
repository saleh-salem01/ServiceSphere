using AutoMapper;
using PlatformServices.Dtos;
using PlatformServices.Models;

namespace PlatformServices.Mappings;


    public class PlatformsProfiles : Profile
    {
        // Constructor matching the class name
        public PlatformsProfiles()
        {
            // source --> target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }

