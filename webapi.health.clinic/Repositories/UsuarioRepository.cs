using webapi.health.clinic.Context;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext ctx;
        public UsuarioRepository() => ctx = new HealthClinicContext();

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            
        }

        public Usuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        private List<Usuario> ListarTodos()
        {
            try
            {
                List<Usuario> listaUsuarios = ctx.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    IdTipoUsuario = u.IdTipoUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Telefone = u.Telefone,
                    IdTipoUsuarioNavigation = u.IdTipoUsuarioNavigation,
                }).ToList();

                return listaUsuarios;
            }
            catch (Exception)
            { throw; }
        }

        public void Cadastrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListarMinhasConsultas(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
