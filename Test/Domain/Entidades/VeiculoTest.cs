using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedadesVeiculo()
    {
        //Arrange - todas as variaveis criadas para fazer validacoes...
        var veiculo = new Veiculo();

        //Act - todas as ações que vamos fazer...
        veiculo.Id = 1;
        veiculo.Nome = "Fiesta";
        veiculo.Marca = "Ford";
        veiculo.Ano = 2013;

        //Assert - onde é feita a validação dos dados...
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Fiesta", veiculo.Nome);
        Assert.AreEqual("Ford", veiculo.Marca);
        Assert.AreEqual(2013, veiculo.Ano);
    } 
}
