//this is the interface allows au to deal with platforms 
using PlatformServices.Models;

namespace PlatformServices.Data;
public interface IPlatformRepo
{
    bool SavedChanges();

    //CRUD Operation of the platform
    void CreatePlatform(Platform platform);
    Platform GetPlatformById(int id);
    IEnumerable<Platform> GetAllPlatforms();


}