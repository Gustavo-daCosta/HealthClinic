using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext ctx;
        public EspecialidadeRepository() => ctx = new HealthClinicContext();

        public void Atualizar(Guid id, Especialidade especialidade)
        {
            try
            {
                Especialidade especialidadeBuscada = BuscarPorId(id);

                if (especialidadeBuscada != null)
                {
                    especialidadeBuscada.IdEspecialidade = especialidade.IdEspecialidade;
                    especialidadeBuscada.TituloEspecialidade = especialidade.TituloEspecialidade;
                    especialidadeBuscada.Medicos = especialidade.Medicos;
                    ctx.Especialidade.Update(especialidadeBuscada);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public Especialidade BuscarPorId(Guid id)
        {
            try
            {
                Especialidade especialidadeBuscada = Listar().FirstOrDefault(e => e.IdEspecialidade == id)!;
                return especialidadeBuscada;
            }
            catch (Exception)
            { throw; }
        }

        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                ctx.Especialidade.Add(especialidade);
                ctx.SaveChanges();
            }
            catch (Exception)
            { throw; }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Especialidade especialidadeBuscada = BuscarPorId(id);
                if (especialidadeBuscada != null)
                {
                    ctx.Especialidade.Remove(especialidadeBuscada);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public List<Especialidade> Listar()
        {
            try
            {
                List<Especialidade> listaEspecialidades = ctx.Especialidade.Select(e => new Especialidade
                {
                    IdEspecialidade = e.IdEspecialidade,
                    TituloEspecialidade = e.TituloEspecialidade,
                    Medicos = e.Medicos,
                }).ToList();

                return listaEspecialidades;
            }
            catch (Exception)
            { throw; }
        }
    }
}
