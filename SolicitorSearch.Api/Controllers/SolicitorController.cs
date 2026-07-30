using Microsoft.AspNetCore.Mvc;

namespace SolicitorSearch.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SolicitorController : ControllerBase
{
    private readonly ISolicitorService _solicitorService;

    public SolicitorController(ISolicitorService solicitorService)
    {
        _solicitorService = solicitorService;
    }

    [HttpGet("/Solicitor/{location}")]
    public async Task<IActionResult> Get(string location)
    {
        var solicitors = await _solicitorService.GetSolicitorsByLocation(location);
        return Ok(solicitors);
    }
}
