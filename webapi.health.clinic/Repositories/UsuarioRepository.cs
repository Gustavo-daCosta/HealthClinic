using webapi.health.clinic.Context;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Utils;

namespace webapi.health.clinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext ctx;
        public UsuarioRepository() => ctx = new HealthClinicContext();

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ListarTodos().FirstOrDefault(u => u.Email == email)!;
                
                if (usuarioBuscado != null)
                {
                    bool senhaValida = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (senhaValida)
                        return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            { throw; }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = ListarTodos().FirstOrDefault(u => u.IdUsuario == id)!;
                return usuarioBuscado;
            }
            catch (Exception)
            { throw; }
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
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);

                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            { throw; }
        }

        public List<Consulta> ListarMinhasConsultas(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
