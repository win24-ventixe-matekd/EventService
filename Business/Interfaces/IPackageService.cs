using Business.Models;

namespace Business.Interfaces;

public interface IPackageService
{
    Task<EventResult<Package>> GetAsync(string id);
}
