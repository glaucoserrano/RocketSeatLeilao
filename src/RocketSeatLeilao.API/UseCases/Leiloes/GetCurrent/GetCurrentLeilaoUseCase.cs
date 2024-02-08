using RocketSeatLeilao.API.Contracts;
using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.UseCases.Leiloes.GetCurrent;

public class GetCurrentLeilaoUseCase
{
    private readonly ILeilaoRepository _repository;
public GetCurrentLeilaoUseCase(ILeilaoRepository repository)
    {
        _repository = repository;
    }

    public Auction? Execute()
    {
        return _repository.GetCurrent();
       
    }
}
