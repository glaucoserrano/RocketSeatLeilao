using RocketSeatLeilao.API.Contracts;
using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.Repositories.DataAcess;

public class UserRepository : IUserRepository
{
    private readonly RocketSeatLeilaoDbContext _dbContext;
    public UserRepository(RocketSeatLeilaoDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email) => _dbContext.Users.Any(user => user.Email.Equals(email));

    public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
}
