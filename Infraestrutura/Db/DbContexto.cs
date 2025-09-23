using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.Entidades;

namespace minimal_api.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;
        public DbContexto(IConfiguration configuracaoAppSettings)
        {
            _configuracaoAppSettings = configuracaoAppSettings; //Configuracao pelo construtor
        }
        public DbSet<Administrador> Administradores { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //caso a configuracao nao tenha ocoriido pelo contrutor vai ser feita aqui...
                var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString(); //o '?' é para se nao encontrar nada retornar vazio...
                if (!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
                }
            }
            
            
        }
        
    }
}