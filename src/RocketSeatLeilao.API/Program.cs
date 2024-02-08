using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RocketSeatLeilao.API.Contracts;
using RocketSeatLeilao.API.Filters;
using RocketSeatLeilao.API.Repositories;
using RocketSeatLeilao.API.Repositories.DataAcess;
using RocketSeatLeilao.API.Services;
using RocketSeatLeilao.API.UseCases.Leiloes.GetCurrent;
using RocketSeatLeilao.API.UseCases.Ofertas.CreateOffer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below;
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<AuthenticationUserAttribute>();
builder.Services.AddScoped<LoggedUser>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<GetCurrentLeilaoUseCase>();
builder.Services.AddScoped<ILeilaoRepository, LeilaoRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoggedUser, LoggedUser>();

builder.Services.AddDbContext<RocketSeatLeilaoDbContext>(options =>
{
    options.UseSqlite(@"Data Source=D:\Cursos\RocketSeat\NLW Expert\Trilha C#\Dados\leilaoDbNLW.db");
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
