using Microsoft.AspNetCore.Mvc;
using RocketSeatLeilao.API.Entities;
using RocketSeatLeilao.API.UseCases.Leiloes.GetCurrent;

namespace RocketSeatLeilao.API.Controller;

[Route("[controller]")]
[ApiController]
public class LeilaoController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentLeilao()
    {
        var useCase = new GetCurrentLeilaoUseCase();

        var result = useCase.Execute();

        if(result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }
}
