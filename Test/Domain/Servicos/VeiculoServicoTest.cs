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
    public class VeiculoServicoTest
    {
        [TestMethod]
        public void TestandoSalvarVeiculo()
        {
            //Arrange - todas as variaveis criadas para fazer validacoes...
            var context = Setup.CriarVeiculoServicoParaTeste();
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
            var context = Setup.CriarVeiculoServicoParaTeste();
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
    }
}