using RocketSeatLeilao.API.Contracts;
using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.Repositories.DataAcess;

public class OfferRepository: IOfferRepository
{
    private readonly RocketSeatLeilaoDbContext _dbContext;
    public OfferRepository(RocketSeatLeilaoDbContext dbContext) => _dbContext = dbContext;
    public void Add(Offer offer)
    {

        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();
    }
}
