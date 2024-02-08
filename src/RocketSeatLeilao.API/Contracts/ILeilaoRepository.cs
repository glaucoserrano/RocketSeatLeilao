using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.Contracts;

public interface ILeilaoRepository
{
    Auction? GetCurrent();
}
