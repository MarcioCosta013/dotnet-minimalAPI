using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrutura.Db;

namespace minimal_api.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;

        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Apagar(Administrador administrador)
        {
            _contexto.Administradores.Remove(administrador);
            _contexto.SaveChanges();
        }

        public void Atualizar(Administrador administrador)
        {
            _contexto.Administradores.Update(administrador);
            _contexto.SaveChanges();
        }

        public Administrador? BuscaPorId(int id)
        {
            return _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();
        }

        public Administrador? BuscaPorId(Administrador administradord)
        {
            throw new NotImplementedException();
        }

        public Administrador Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault(); //FirstOrDefault retorna alguma coisa ou nulo
            return adm;
        }

        public List<Administrador> Todos(int? pagina = 1) //permite tanto dividir o retorno por pagina como trazer todos juntos de o valor passado for Null.
        {
            var query = _contexto.Administradores.AsQueryable();
            
            int itensPorPagina = 10;

            if (pagina != null) //se pagina for null trás todos os dados juntos
            {
                query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }

            return query.ToList();
        }
    }  
}