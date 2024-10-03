using PlatformServices.Models;

namespace PlatformServices.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext _context;

    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }

    public void CreatePlatform(Platform platform)
    {
        if (platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }
        _context.platforms.Add(platform);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        var Plat = _context.platforms.FirstOrDefault(p => p.Id == id);
        if (Plat == null)
        {
            throw new Exception($"Platform with id {id} not found");
        }
        return Plat;
    }

    public bool SavedChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
