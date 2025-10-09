using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {

        //Construtor ideal para usar em diferentes ambientes: Produçao, desenvolvimento e testes.
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) // o padrão para injeção de dependência e testes unitários.
        {}

        //Mapeamento
        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            #region comentário OnModelCreating
                /*
                Esse metodo é chamado automaticamente pelo Entity Framework Core quando o contexto é inicializado.
                Nesse método, você está usando o HasData para inserir dados iniciais (seeding) na tabela de Administrador.
                Ou seja, sempre que o banco for criado ou atualizado via migrations, esse registro será inserido.
                */
            #endregion
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Email = "administrador@test.com",
                    Senha = "123456",
                    Perfil = "Adm"
                }
            );
        }
    }
}