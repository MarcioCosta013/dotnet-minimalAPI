using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            //Configurar o ConfigurationBuilder
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //Para que o .NET saiba qual arquivo appsettings.json usar e assim não alterar o real.
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory()) //se o path vier nulo ...
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores"); //para limpar a tabela...

            var adm = new Administrador();
            adm.Email = "teste@test.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var adminstradorServico = new AdministradorServico(context);

            //Act - todas as ações que vamos fazer...
            adminstradorServico.Incluir(adm);

            //Assert - onde é feita a validação dos dados...
            Assert.AreEqual(1, adminstradorServico.Todos(1).Count());

        }
        
        [TestMethod]
        public void TestandoBuscaPorId()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores"); //para limpar a tabela...

            var adm = new Administrador();
            adm.Email = "teste@test.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var adminstradorServico = new AdministradorServico(context);

            //Act - todas as ações que vamos fazer...
            adminstradorServico.Incluir(adm);
            var admDoBanco = adminstradorServico.BuscaPorId(adm.Id);

            //Assert - onde é feita a validação dos dados...
            Assert.AreEqual(1, admDoBanco.Id);
            
        }
    }
}