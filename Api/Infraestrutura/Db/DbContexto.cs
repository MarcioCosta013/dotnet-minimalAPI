using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;

        //Construtor padrao para producao
        public DbContexto(IConfiguration configuracaoAppSettings)
        {
            _configuracaoAppSettings = configuracaoAppSettings; //Configuracao pelo construtor
        }

        //Construtor para testes
        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {
        }

        //Mapeamento
        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Email = "administrador@test.com",
                    Senha = "123456",
                    Perfil = "adm"
                }
            );
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && _configuracaoAppSettings != null)
            {
                //caso a configuracao nao tenha ocorrido pelo contrutor vai ser feita aqui...
                var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString(); //o '?' é para se nao encontrar nada retornar vazio...
                if (!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
                }
            }


        }
        
    }
}