using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using Test.Helpers;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class VeiculoServicoTest
    {
        [TestMethod]
        public void TestandoIncluirVeiculo()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarContextoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores"); //para limpar a tabela...

            var veiculo = new Veiculo();
            veiculo.Nome = "Onix";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2020;

            var administradorServico = new VeiculoServico(context);

            //Act - todas as ações que vamos fazer...
            administradorServico.Incluir(veiculo);

            //Assert - onde é feita a validação dos dados...
            Assert.AreEqual(1, administradorServico.Todos(1).Count());

        }

        [TestMethod]
        public void TestandoBuscaPorId()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarContextoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores"); //para limpar a tabela... DELETE PARA O SQLITE

            var veiculo = new Veiculo();
            veiculo.Nome = "Onix";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2020;

            var adminstradorServico = new VeiculoServico(context);

            //Act - todas as ações que vamos fazer...
            adminstradorServico.Incluir(veiculo);
            context.SaveChanges(); //Salve as mudanças no banco de dados...
            var admDoBanco = adminstradorServico.BuscaPorId(veiculo.Id);

            //Assert - onde é feita a validação dos dados...
            Assert.AreEqual(veiculo.Id, admDoBanco?.Id);
        }

        [TestMethod]
        public void TestandoBuscaTodosVeiculosPorPagina()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarContextoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores"); //para limpar a tabela...

            for (int i = 1; i <= 25; i++)
            {
                var veiculo = new Veiculo();
                veiculo.Nome = $"Onix{i}";
                veiculo.Marca = "Chevolet";
                veiculo.Ano = 2020;
                context.Veiculos.Add(veiculo);
            };
            context.SaveChanges(); //Salve as mudanças no banco de dados...

            var veiculos = new VeiculoServico(context);

            //Act - todas as ações que vamos fazer...
            var pagina1 = veiculos.Todos(1);
            var pagina2 = veiculos.Todos(2);
            var pagina3 = veiculos.Todos(3);

            //Assert - onde é feita a validação dos dados...
            Assert.AreEqual(10, pagina1.Count());
            Assert.AreEqual("Onix1", pagina1.First().Nome);
            Assert.AreEqual(10, pagina2.Count());
            Assert.AreEqual("Onix11", pagina2.First().Nome);
            Assert.AreEqual(5, pagina3.Count());
            Assert.AreEqual("Onix21", pagina3.First().Nome);
        }

        [TestMethod]
        public void TestandoBuscaTodosVeiculosPaginaNull()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarContextoParaTeste();
            context.Database.ExecuteSqlRaw("DELETE FROM Administradores"); //para limpar a tabela...

            for (int i = 1; i <= 9; i++)
            {
                var veiculo = new Veiculo();
                veiculo.Nome = $"Onix{i}";
                veiculo.Marca = "Chevolet";
                veiculo.Ano = 2020;
                context.Veiculos.Add(veiculo);
            };
            context.SaveChanges(); //Salve as mudanças no banco de dados...

            var veiculos = new VeiculoServico(context);


            //ACT - acoes
            var resultado = veiculos.Todos(null);

            //Assert
            Assert.AreEqual(9, resultado.Count);
        }
    }
}