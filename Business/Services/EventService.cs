using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;
public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<EventResult> CreateAsync(CreateEventModel model)
    {
        try
        {
            var entity = new EventEntity
            {
                Title = model.Title,
                Description = model.Description,
                Date = model.Date,
                Location = model.Location
            };

            var result = await _eventRepository.AddAsync(entity);
            return result.Success
                ? new EventResult { Success = true, StatusCode = 201 }
                : new EventResult { Success = false, StatusCode = 500, Error = result.Error };
        }
        catch (Exception ex)
        {
            return new EventResult { Success = false, StatusCode = 500, Error = ex.Message };
        }
    }

    public async Task<EventResult<IEnumerable<Event>>> GetAllAsync()
    {
        var result = await _eventRepository.GetAllAsync();
        if (!result.Success)
            return new EventResult<IEnumerable<Event>> { Success = false, StatusCode = result.StatusCode, Error = result.Error };
        
        var events = result.Result!.Select(x => new Event
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Date = x.Date,
            Location = x.Location
        });

        return new EventResult<IEnumerable<Event>> { Success = true, StatusCode = 200, Result = events };
    }

    public async Task<EventResult<Event>> GetAsync(string id)
    {
        var result = await _eventRepository.GetAsync(x => x.Id == id, includes: x => x.Packages);
        if (!result.Success || result.Result == null)
            return new EventResult<Event> { Success = false, StatusCode = result.StatusCode, Error = "Event not found" };

        var CurrentEvent = new Event
        {
            Id = result.Result.Id,
            Title = result.Result.Title,
            Description = result.Result.Description,
            Date = result.Result.Date,
            Location = result.Result.Location,
            Packages = result.Result.Packages.Select(x => new Package
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Seeting = x.Seeting,
                Price = x.Price,
                Currency = x.Currency
            })
        };

        return new EventResult<Event> { Success = true, StatusCode = 200, Result = CurrentEvent };
    }
}
