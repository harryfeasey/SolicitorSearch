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

    [HttpGet("/SolicitorApi/{location}")]
    public async Task<IActionResult> Get(string location)
    {
        var solicitors = await _solicitorService.GetSolicitorsByLocation(location);
        return Ok(solicitors);
    }

    [HttpGet("/SolicitorApi/Report/")]
    public async Task<IActionResult> Get()
    {
        var report = await _solicitorService.GetSolicitorsReportForAllLocations();
        return Ok(report);
    }
}
