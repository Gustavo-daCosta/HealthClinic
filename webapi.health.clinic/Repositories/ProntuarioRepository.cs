using webapi.health.clinic.Context;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly HealthClinicContext ctx;
        public ProntuarioRepository() => ctx = new HealthClinicContext();

        public void Atualizar(Guid id, Prontuario prontuario)
        {
            try
            {
                Prontuario prontuarioBuscado = BuscarPorId(id);

                if (prontuarioBuscado != null)
                {
                    prontuarioBuscado.IdProntuario = prontuario.IdProntuario;
                    prontuarioBuscado.IdConsulta = prontuario.IdConsulta;
                    prontuarioBuscado.Descricao = prontuario.Descricao;
                    prontuarioBuscado.DataCriacao = prontuario.DataCriacao;
                    prontuarioBuscado.IdConsultaNavigation = prontuario.IdConsultaNavigation;
                    ctx.Prontuario.Update(prontuarioBuscado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public Prontuario BuscarPorId(Guid id)
        {
            try
            {
                Prontuario prontuarioBuscado = Listar().FirstOrDefault(c => c.IdProntuario == id)!;
                return prontuarioBuscado;
            }
            catch (Exception)
            { throw; }
        }

        public void Cadastrar(Prontuario prontuario)
        {
            try
            {
                ctx.Prontuario.Add(prontuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            { throw; }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Prontuario prontuarioBuscado = BuscarPorId(id);
                if (prontuarioBuscado != null)
                {
                    ctx.Prontuario.Remove(prontuarioBuscado);
                    ctx.SaveChanges();
                }
                return;
            }
            catch (Exception)
            { throw; }
        }

        public List<Prontuario> Listar()
        {
            try
            {
                List<Prontuario> listaProntuarios = ctx.Prontuario.Select(p => new Prontuario
                {
                    IdProntuario = p.IdProntuario,
                    IdConsulta = p.IdConsulta,
                    Descricao = p.Descricao,
                    DataCriacao = p.DataCriacao,
                    IdConsultaNavigation = new Consulta
                    {
                        IdConsulta = p.IdConsultaNavigation.IdConsulta,
                        IdClinica = p.IdConsultaNavigation.IdClinica,
                        IdMedico = p.IdConsultaNavigation.IdMedico,
                        IdPaciente = p.IdConsultaNavigation.IdPaciente,
                        Data = p.IdConsultaNavigation.Data,
                        Situacao = p.IdConsultaNavigation.Situacao,
                    }
                }).ToList();

                return listaProntuarios;
            }
            catch (Exception)
            { throw; }
        }
    }
}
