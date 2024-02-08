using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatLeilao.API.Communication.Requests;
using RocketSeatLeilao.API.Contracts;
using RocketSeatLeilao.API.Entities;
using RocketSeatLeilao.API.Services;
using RocketSeatLeilao.API.UseCases.Ofertas.CreateOffer;
using Xunit;

namespace UseCase.test.Ofertas.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Sucess(int itemId)
    {
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(50, 1000))
            .Generate();


        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        var act = () => useCase.Execute(itemId, request);

        act.Should().NotThrow();

    }
}
