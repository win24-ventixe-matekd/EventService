using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PackagesController(IPackageService packageService) : Controller
{
    private readonly IPackageService _packageService = packageService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var currentPackage = await _packageService.GetAsync(id);
        return currentPackage.Result != null ? Ok(currentPackage) : NotFound();
    }
}
