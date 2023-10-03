using webapi.health.clinic.Context;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthClinicContext ctx;
        public ComentarioRepository() => ctx = new HealthClinicContext();

        public void Atualizar(Guid id, Comentario comentario)
        {
            try
            {
                Comentario comentarioBuscado = BuscarPorId(id);

                if (comentarioBuscado != null)
                {
                    comentarioBuscado.IdComentario = comentario.IdComentario;
                    comentarioBuscado.IdConsulta = comentario.IdConsulta;
                    comentarioBuscado.Descricao = comentario.Descricao;
                    comentarioBuscado.DataCriacao = comentario.DataCriacao;
                    comentarioBuscado.Exibe = comentario.Exibe;
                    comentarioBuscado.IdConsultaNavigation = comentario.IdConsultaNavigation;
                    ctx.Comentario.Update(comentarioBuscado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public Comentario BuscarPorId(Guid id)
        {
            try
            {
                Comentario comentarioBuscado = Listar().FirstOrDefault(c => c.IdComentario == id)!;
                return comentarioBuscado;
            }
            catch (Exception)
            { throw; }
        }

        public void Cadastrar(Comentario comentario)
        {
            try
            {
                ctx.Comentario.Add(comentario);
                ctx.SaveChanges();
            }
            catch (Exception)
            { throw; }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Comentario comentarioBuscado = BuscarPorId(id);
                if (comentarioBuscado != null)
                {
                    ctx.Comentario.Remove(comentarioBuscado);
                    ctx.SaveChanges();
                }
                return;
            }
            catch (Exception)
            { throw; }
        }

        public List<Comentario> Listar()
        {
            try
            {
                List<Comentario> listaComentarios = ctx.Comentario.Select(c => new Comentario
                {
                    IdComentario = c.IdComentario,
                    IdConsulta = c.IdConsulta,
                    Descricao = c.Descricao,
                    DataCriacao = c.DataCriacao,
                    Exibe = c.Exibe,
                    IdConsultaNavigation = new Consulta
                    {
                        IdConsulta = c.IdConsultaNavigation.IdConsulta,
                        IdClinica = c.IdConsultaNavigation.IdClinica,
                        IdMedico = c.IdConsultaNavigation.IdMedico,
                        IdPaciente = c.IdConsultaNavigation.IdPaciente,
                        Data = c.IdConsultaNavigation.Data,
                        Situacao = c.IdConsultaNavigation.Situacao,
                    }
                }).ToList();

                return listaComentarios;
            }
            catch (Exception)
            { throw; }
        }
    }
}
