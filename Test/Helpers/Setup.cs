using Microsoft.EntityFrameworkCore;
using minimal_api.Infraestrutura.Db;
using minimal_api.Dominio.Servicos;

namespace Test.Helpers;

public static class Setup
{
    public static DbContexto CriarAdministradorServicoParaTeste()
    {
        var options = new DbContextOptionsBuilder<DbContexto>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        var contexto = new DbContexto(options);
        contexto.Database.OpenConnection();
        contexto.Database.EnsureCreated();

        return contexto;
    }
}