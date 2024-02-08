using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
