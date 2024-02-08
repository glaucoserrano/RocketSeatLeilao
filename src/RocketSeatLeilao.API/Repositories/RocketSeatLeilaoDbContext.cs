using Microsoft.EntityFrameworkCore;
using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.Repositories;

public class RocketSeatLeilaoDbContext : DbContext
{
    public RocketSeatLeilaoDbContext(DbContextOptions options): base(options) {  }

    public DbSet<Auction>? Auctions { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Offer>? Offers { get; set; }

}
