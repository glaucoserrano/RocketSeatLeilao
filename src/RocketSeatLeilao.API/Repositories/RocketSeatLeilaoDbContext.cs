using Microsoft.EntityFrameworkCore;
using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.Repositories;

public class RocketSeatLeilaoDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=D:\Cursos\RocketSeat\NLW Expert\Trilha C#\Dados\leilaoDbNLW.db");
    }
}
