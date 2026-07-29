using Microsoft.AspNetCore.Mvc;
using Models;

namespace SolicitorSearch.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SolicitorController : ControllerBase
{
    private readonly ISolicitorService _solicitorService;

    public SolicitorController(SolicitorService solicitorService)
    {
        _solicitorService = solicitorService;
    }

    [HttpGet("/{location}")]
    public async Task<IActionResult> Get(string location)
    {
        var solicitors = await _solicitorService.GetSolicitorsByLocation(location);
        return Ok(solicitors);
    }
}
