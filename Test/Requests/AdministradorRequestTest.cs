using System.Net;
using System.Text;
using System.Text.Json;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.ModelViews;
using Test.Helpers;

namespace Test.Requests;

[TestClass]
public class AdministradorRequestTest
{    
    [TestMethod]
    public async Task TestarGetSetPropriedades()
    {
        // Arrange
        var loginDTO = new LoginDTO{
            Email = "administrador@test.com",
            Senha = "123456"
        };

        var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8,  "Application/json");
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5038"); 

        // Act
        var response = await client.PostAsync("/administradores/login", content);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadAsStringAsync();
        var admLogado = JsonSerializer.Deserialize<AdministradorLogado>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.IsNotNull(admLogado?.Email ?? "");
        Assert.IsNotNull(admLogado?.Perfil ?? "");
        Assert.IsNotNull(admLogado?.Token ?? "");

        Console.WriteLine(admLogado?.Token);
    }
}