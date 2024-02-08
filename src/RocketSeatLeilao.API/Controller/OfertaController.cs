using Microsoft.AspNetCore.Mvc;
using RocketSeatLeilao.API.Communication.Requests;
using RocketSeatLeilao.API.Filters;
using RocketSeatLeilao.API.UseCases.Ofertas.CreateOffer;

namespace RocketSeatLeilao.API.Controller;
[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfertaController : RocketSeatLeilaoBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    
    public IActionResult CreateOffer(
        [FromRoute] int itemId, 
        [FromBody]RequestCreateOfferJson request, 
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty,id);
    }
}
