using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Internalization.Controllers.Api;
[ApiController]
[Route("/api/[controller]")]
public class TestPathController : ControllerBase {
    private readonly IStringLocalizer<TestPathController> _localizer;
    public TestPathController(IStringLocalizer<TestPathController> localizer) {
        _localizer = localizer;
    }
    [HttpGet("test")]
    public IActionResult Test() {
        
        return Ok(_localizer["testValue"]);
    }
}