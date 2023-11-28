using System.Threading.Tasks;
using Interview.Data.Models;
using Interview.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Api.Controllers;

[ApiController]
[Route("SelectedTenant")]
public class SelectedTenantController : Controller
{
    private readonly IUserPreferenceService _service;

    public SelectedTenantController(IUserPreferenceService userPreferenceService)
    {
        _service = userPreferenceService;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrUpdateSelectedTenant(SelectedTenant selectedTenant)
    {
        await _service.AddOrUpdateSelectedTenant(selectedTenant);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetSelectedTenant(string email)
    {
        var result = await _service.GetSelectedTenant(email);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
