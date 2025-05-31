using Business.Models;

namespace Business.Interfaces;

public interface IEventService
{
    Task<EventResult> CreateAsync(CreateEventModel model);
    Task<EventResult<IEnumerable<Event>>> GetAllAsync();
    Task<EventResult<Event>> GetAsync(string id);
}
