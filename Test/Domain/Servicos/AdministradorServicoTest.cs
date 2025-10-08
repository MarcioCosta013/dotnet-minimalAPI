using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;
using Test.Helpers;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class AdministradorServicoTest
    {
        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarAdministradorServicoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores"); //para limpar a tabela...

            var adm = new Administrador();
            adm.Email = "teste@test.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var administradorServico = new AdministradorServico(context);

            //Act - todas as ações que vamos fazer...
            administradorServico.Incluir(adm);

            //Assert - onde é feita a validação dos dados...
            Assert.AreEqual(1, administradorServico.Todos(1).Count());

        }

        [TestMethod]
        public void TestandoBuscaPorId()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarAdministradorServicoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores"); //para limpar a tabela... DELETE PARA O SQLITE

            var adm = new Administrador();
            adm.Email = "teste@test.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var adminstradorServico = new AdministradorServico(context);

            //Act - todas as ações que vamos fazer...
            adminstradorServico.Incluir(adm);
            context.SaveChanges(); //Salve as mudanças no banco de dados...
            var admDoBanco = adminstradorServico.BuscaPorId(adm.Id);

            //Assert - onde é feita a validação dos dados...
            Assert.AreEqual(adm.Id, admDoBanco?.Id);
        }
    }
}