using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class PackageService(IPackageRepository packageRepository) : IPackageService
{
    private readonly IPackageRepository _packageRepository = packageRepository;

    public async Task<EventResult<Package>> GetAsync(string id)
    {
        var result = await _packageRepository.GetAsync(x => x.Id == id, includes: x => x.Event);
        if (!result.Success || result.Result == null)
            return new EventResult<Package> { Success = false, StatusCode = result.StatusCode, Error = "Package not found" };

        var PackageEvent = result.Result.Event;
        var CurrentPackage = new Package
        {
            Id = result.Result.Id,
            Name = result.Result.Name,
            Description = result.Result.Description ?? "",
            Seating = result.Result.Seating,
            Price = result.Result.Price,
            Currency = result.Result.Currency,
            Event = new Event
            {
                Id = PackageEvent.Id,
                Title = PackageEvent.Title,
                Description = PackageEvent.Description ?? "",
                Date = PackageEvent.Date,
                Location = PackageEvent.Location,
            }
        };

        return new EventResult<Package> { Success = true, StatusCode = 200, Result = CurrentPackage };
    }

    public async Task<EventResult> CreateAsync(CreatePackageModel model)
    {
        try
        {
            var entity = new PackageEntity
            {
                Name = model.Name,
                Description = model.Description,
                Seating = model.Seating,
                Price = model.Price,
                Currency = model.Currency,
                EventId = model.EventId,
            };

            var result = await _packageRepository.AddAsync(entity);
            return result.Success
                ? new EventResult { Success = true, StatusCode = 201 }
                : new EventResult { Success = false, StatusCode = 500, Error = result.Error };
        }
        catch (Exception ex)
        {
            return new EventResult { Success = false, StatusCode = 500, Error = ex.Message };
        }
    }
}
