using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventService eventService) : Controller
{
    private readonly IEventService _eventService = eventService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _eventService.GetAllAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var currentEvent = await _eventService.GetAsync(id);
        return currentEvent.Result != null ? Ok(currentEvent) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEventModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = await _eventService.CreateAsync(model);
        return result.Success ? Ok(result) : StatusCode(500, result.Error);
    }
}
