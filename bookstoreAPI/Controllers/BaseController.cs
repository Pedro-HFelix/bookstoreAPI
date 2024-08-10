using Microsoft.AspNetCore.Mvc;

namespace bookstoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : Controller
{
    [HttpGet("heathy")]
    public IActionResult Heathy()
    {
        return Ok("It`s working");
    }
}