using Microsoft.AspNetCore.Mvc;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
public class EventsController(IEventService eventService) : Controller
{
    private readonly IEventService _eventService = eventService;
}
