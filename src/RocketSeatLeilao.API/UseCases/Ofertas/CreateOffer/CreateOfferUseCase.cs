using RocketSeatLeilao.API.Communication.Requests;
using RocketSeatLeilao.API.Contracts;
using RocketSeatLeilao.API.Entities;
using RocketSeatLeilao.API.Services;

namespace RocketSeatLeilao.API.UseCases.Ofertas.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferRepository _repository;

    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository) 
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        
        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.UtcNow,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        _repository.Add(offer);
        return offer.Id;
    }
}
