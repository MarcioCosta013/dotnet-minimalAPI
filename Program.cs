var builder = WebApplication.CreateBuilder(args);
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
public class LoginDTO()
{
    public string Email { get; set; }
    public string Senha { get; set; }

}