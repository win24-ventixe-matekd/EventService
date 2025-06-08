using Business.Models;

namespace Business.Interfaces;

public interface IPackageService
{
    Task<EventResult> CreateAsync(CreatePackageModel model);
    Task<EventResult<Package>> GetAsync(string id);
}
