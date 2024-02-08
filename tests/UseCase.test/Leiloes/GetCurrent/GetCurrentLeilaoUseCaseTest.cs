using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatLeilao.API.Contracts;
using RocketSeatLeilao.API.Entities;
using RocketSeatLeilao.API.ENums;
using RocketSeatLeilao.API.UseCases.Leiloes.GetCurrent;
using Xunit;

namespace UseCase.test.Leiloes.GetCurrent;
public class GetCurrentLeilaoUseCaseTest
{
    [Fact]
    public void Sucess()
    {
        var entity = new Faker<Auction>()
            .RuleFor(leilao => leilao.Id, f => f.Random.Number(1, 20))
            .RuleFor(leilao => leilao.Name, f => f.Lorem.Word())
            .RuleFor(leilao => leilao.Starts, f => f.Date.Past()) 
            .RuleFor(leilao => leilao.Ends, f=> f.Date.Future())
            .RuleFor(leilao => leilao.Itens, (f,leilao) => new List<Item>
            {
                new Item
                {
                    Id= f.Random.Number(1, 20),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50,1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = leilao.Id
                }
            }).Generate();

        var mock = new Mock<ILeilaoRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);

        var useCase = new GetCurrentLeilaoUseCase(mock.Object);

        var leilao = useCase.Execute();

        leilao.Should().NotBeNull();
        leilao.Id.Should().Be(entity.Id);
        leilao.Name.Should().Be(entity.Name);
        leilao.Starts.Should().Be(entity.Starts);
        leilao.Ends.Should().Be(entity.Ends);
        

    }
}
