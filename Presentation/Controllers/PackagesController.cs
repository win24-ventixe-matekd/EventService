using Business.Interfaces;
using Business.Models;
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

    [HttpPost]
    public async Task<IActionResult> Create(CreatePackageModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = await _packageService.CreateAsync(model);
        return result.Success ? Ok(result) : StatusCode(500, result.Error);
    }
}
