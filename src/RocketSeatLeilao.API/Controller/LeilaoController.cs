using Microsoft.AspNetCore.Mvc;
using RocketSeatLeilao.API.Entities;
using RocketSeatLeilao.API.UseCases.Leiloes.GetCurrent;

namespace RocketSeatLeilao.API.Controller;

public class LeilaoController : RocketSeatLeilaoBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentLeilao([FromServices] GetCurrentLeilaoUseCase useCase)
    {
        

        var result = useCase.Execute();

        if(result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

}
