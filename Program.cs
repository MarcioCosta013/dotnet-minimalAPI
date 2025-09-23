using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql")) //Na injecao de dependencia já faz essa string ser passar e caso no overrider tbm se estiver vazio
    );
});
var app = builder.Build();

app.MapGet("/", () => "Hello World454545!");


app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Acesso feito com sucesso!");
    else
        return Results.Unauthorized();
});

app.Run();