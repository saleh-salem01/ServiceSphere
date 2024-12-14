using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformServices.Data;
using PlatformServices.Dtos;
using PlatformServices.Models;

namespace PlatformServices.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<PlatformsController> _logger;

    public PlatformsController(
        IPlatformRepo repository,
        IMapper mapper,
        ILogger<PlatformsController> logger
    )
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        try
        {
            _logger.LogInformation("--> Getting Platforms");
            var platformsItems = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformsItems));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get platforms: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        try
        {
            _logger.LogInformation("--> Getting Platform");
            var platformsItem = _repository.GetPlatformById(id);
            if (platformsItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PlatformReadDto>(platformsItem));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get platform: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        try
        {
            _logger.LogInformation("--> Creating Platform");
            var PlatformItem = _mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(PlatformItem);
            _repository.SavedChanges();
            var Item = _mapper.Map<PlatformReadDto>(PlatformItem);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = Item.Id }, Item);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get platform: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}
