using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;

namespace Test.Mocks
{
    public class AdministradorServicoMock : IAdministradorServico
    { //Mock para testes unitários...
        private static List<Administrador> administradores = new List<Administrador>()
        {
            new Administrador{
                Id = 1,
                Email = "adm@test.com",
                Senha = "123456",
                Perfil = "Adm"
            },
            new Administrador{
                Id = 2,
                Email = "editor@test.com",
                Senha = "123456",
                Perfil = "Editor"
            }
        };

        public AdministradorServicoMock()
        {}

        public Administrador? BuscaPorId(int id)
        {
            return administradores.Find(a => a.Id == id);
        }

        public Administrador Incluir(Administrador administrador)
        {
            administrador.Id = administradores.Count() + 1;
            administradores.Add(administrador);

            return administrador;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            return administradores.Find(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
        }

        public List<Administrador> Todos(int? pagina)
        {
            return administradores;
        }
        
        public void Atualizar(Administrador administrador)
        { //Assim, o método Atualizar localiza o administrador pelo Id e atualiza seus dados na lista.
            var index = administradores.FindIndex(a => a.Id == administrador.Id);
            if (index != -1)
            {
                administradores[index] = administrador;
            }
        }

        public void Apagar(Administrador administrador)
        {
            administradores.Remove(administrador);
        }
    }
}