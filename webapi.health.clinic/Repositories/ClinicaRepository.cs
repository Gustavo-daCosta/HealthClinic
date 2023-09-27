using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext ctx;
        public ClinicaRepository() => ctx = new HealthClinicContext();

        public void Atualizar(Guid id, Clinica clinica)
        {
            try
            {
                Clinica clinicaBuscada = BuscarPorId(id);

                if (clinicaBuscada != null)
                {
                    clinicaBuscada.IdClinica = clinica.IdClinica;
                    clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
                    clinicaBuscada.Endereco = clinica.Endereco;
                    clinicaBuscada.Cnpj = clinica.Cnpj;
                    clinicaBuscada.Consultas = clinica.Consultas;
                    clinicaBuscada.Medicos = clinica.Medicos;
                    ctx.Clinica.Update(clinicaBuscada);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public Clinica BuscarPorId(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = Listar().FirstOrDefault(c => c.IdClinica == id)!;
                return clinicaBuscada;
            }
            catch (Exception)
            { throw; }
        }

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
            catch (Exception)
            { throw; }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = BuscarPorId(id);
                if (clinicaBuscada != null)
                {
                    ctx.Clinica.Remove(clinicaBuscada);
                    ctx.SaveChanges();
                }
                return;
            }
            catch (Exception)
            { throw; }
        }

        public List<Clinica> Listar()
        {
            try
            {
                List<Clinica> listaClinicas = ctx.Clinica.Select(c => new Clinica
                {
                    IdClinica = c.IdClinica,
                    RazaoSocial = c.RazaoSocial,
                    Endereco = c.Endereco,
                    Cnpj = c.Cnpj,
                    Consultas = ctx.Consulta.Where(con => con.IdClinica == c.IdClinica).ToList(),
                    Medicos = ctx.Medico.Where(m => m.IdClinica == c.IdClinica).ToList(),
                }).ToList();

                return listaClinicas;
            }
            catch (Exception)
            { throw; }
        }
    }
}
