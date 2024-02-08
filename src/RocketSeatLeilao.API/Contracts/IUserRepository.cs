using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
