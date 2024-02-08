using Microsoft.EntityFrameworkCore;
using RocketSeatLeilao.API.Contracts;
using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.Repositories.DataAcess;

public class LeilaoRepository : ILeilaoRepository
{
    private readonly RocketSeatLeilaoDbContext _dbContext;
    public LeilaoRepository(RocketSeatLeilaoDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.UtcNow;

        return _dbContext
            .Auctions
            .Include(leilao => leilao.Itens)
            .FirstOrDefault(leilao => leilao.Starts <= today && leilao.Ends >= today);
    }
}
