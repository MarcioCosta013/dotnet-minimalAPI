using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorTest
{
    [TestMethod]
    public void TestarGetSetPropriedadesAdministrador()
    {
        //Arrange - todas as variaveis criadas para fazer validacoes...
        var adm = new Administrador();

        //Act - todas as ações que vamos fazer...
        adm.Id = 1;
        adm.Email = "teste@test.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        //Assert - onde é feita a validação dos dados...
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("teste@test.com", adm.Email);
        Assert.AreEqual("teste", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);

    }
}
