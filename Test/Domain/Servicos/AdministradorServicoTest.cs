using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using Test.Helpers;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class AdministradorServicoTest
    {
        [TestMethod]
        public void TestandoIncluirAdministrador()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarContextoParaTeste();
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
        public void TestandoBuscaPorIdAdministrador()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarContextoParaTeste();
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

        [TestMethod]
        public void TestandoBuscaTodosAdministradorPorPagina()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarContextoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores"); //para limpar a tabela...

            for (int i = 1; i <= 25; i++)
            {
                var adm = new Administrador();
                adm.Email = $"teste{i}@test.com";
                adm.Senha = $"teste{i}";
                adm.Perfil = "Adm";
                context.Administradores.Add(adm);
            };
            context.SaveChanges(); //Salve as mudanças no banco de dados...

            var adminstradorServico = new AdministradorServico(context);

            //Act - todas as ações que vamos fazer...
            var pagina1 = adminstradorServico.Todos(1);
            var pagina2 = adminstradorServico.Todos(2);
            var pagina3 = adminstradorServico.Todos(3);

            //Assert - onde é feita a validação dos dados...
            Assert.AreEqual(10, pagina1.Count());
            Assert.AreEqual("teste1@test.com", pagina1.First().Email);
            Assert.AreEqual(10, pagina2.Count());
            Assert.AreEqual("teste11@test.com", pagina2.First().Email);
            Assert.AreEqual(5, pagina3.Count());
            Assert.AreEqual("teste21@test.com", pagina3.First().Email);
        }

        [TestMethod]
        public void TestandoBuscaTodosAdministradorPaginaNull()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarContextoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores"); //para limpar a tabela...

            for (int i = 1; i <= 9; i++)
            {
                var adm = new Administrador();
                adm.Email = $"teste{i}@test.com";
                adm.Senha = $"teste{i}";
                adm.Perfil = "Adm";
                context.Administradores.Add(adm);
            }
            ;
            context.SaveChanges(); //Salve as mudanças no banco de dados...

            var administradorServico = new AdministradorServico(context);

            //ACT - acoes
            var resultado = administradorServico.Todos(null);

            //Assert
            Assert.AreEqual(9, resultado.Count);
        }

        [TestMethod]
        public void TestandoAlteracaoAdministrador()
        {
            //Arrange
            var context = Setup.CriarContextoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores"); //para limpar a tabela... DELETE PARA O SQLITE

            var adm = new Administrador();
            adm.Email = "teste@test.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var adminstradorServico = new AdministradorServico(context);
            adminstradorServico.Incluir(adm);
            context.SaveChanges();

            //Act
            var admDoBanco = adminstradorServico.BuscaPorId(adm.Id);
            admDoBanco.Email = "novoemail@test.com";
            admDoBanco.Senha = "novaSenha";
            if (admDoBanco != null)
                adminstradorServico.Atualizar(admDoBanco);
            context.SaveChanges();

            var admAlterado = adminstradorServico.BuscaPorId(adm.Id);

            //Assert
            Assert.IsNotNull(admAlterado);
            Assert.AreEqual("novoemail@test.com", admAlterado.Email);
            Assert.AreEqual("novaSenha", admAlterado.Senha);
        }

        [TestMethod]
        public void TestandoApagarUmAdinisnistrador()
        {
            // Arrange
            var context = Setup.CriarContextoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores");

            var adm = new Administrador
            {
                Email = "teste@test.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            var administradorServico = new AdministradorServico(context);
            administradorServico.Incluir(adm);
            context.SaveChanges();

            // Act
            administradorServico.Apagar(adm);
            context.SaveChanges();

            var resultado = administradorServico.BuscaPorId(adm.Id);

            // Assert
            Assert.IsNull(resultado);
        }

    }
}