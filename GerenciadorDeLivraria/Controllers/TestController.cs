using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivraria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public IActionResult GetTest()
    {
        return Ok("API ESTÁ FUNCIONANDO CORRETAMENTE, PROSSIGA!");
    }
}
