using Microsoft.EntityFrameworkCore;
using RocketSeatLeilao.API.Entities;
using RocketSeatLeilao.API.Repositories;

namespace RocketSeatLeilao.API.UseCases.Leiloes.GetCurrent;

public class GetCurrentLeilaoUseCase
{
    public Auction? Execute()
    {
        var repository = new RocketSeatLeilaoDbContext();
        var today = DateTime.UtcNow;

        return repository
            .Auctions
            .Include(leilao => leilao.Itens)
            .FirstOrDefault(leilao => leilao.Starts <= today && leilao.Ends >= today);
    }
}
