using webapi.health.clinic.Context;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext ctx;
        public MedicoRepository() => ctx = new HealthClinicContext();

        public void Atualizar(Guid id, Medico medico)
        {
            try
            {
                Medico medicoBuscado = BuscarPorId(id);

                if (medicoBuscado != null)
                {
                    medicoBuscado.IdMedico = medico.IdMedico;
                    medicoBuscado.IdUsuario = medico.IdUsuario;
                    medicoBuscado.IdEspecialidade = medico.IdEspecialidade;
                    medicoBuscado.IdClinica = medico.IdClinica;
                    medicoBuscado.Crm = medico.Crm;
                    medicoBuscado.Consulta = medico.Consulta;
                    ctx.Medico.Update(medicoBuscado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico medicoBuscado = Listar().FirstOrDefault(c => c.IdMedico == id)!;
                return medicoBuscado;
            }
            catch (Exception)
            { throw; }
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                ctx.Medico.Add(medico);
                ctx.SaveChanges();
            }
            catch (Exception)
            { throw; }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Medico medicoBuscado = BuscarPorId(id);
                if (medicoBuscado != null)
                {
                    ctx.Medico.Remove(medicoBuscado);
                    ctx.SaveChanges();
                }
                return;
            }
            catch (Exception)
            { throw; }
        }

        public List<Medico> Listar()
        {
            try
            {
                List<Medico> listaMedicos = ctx.Medico.Select(p => new Medico
                {
                    IdMedico = p.IdMedico,
                    IdUsuario = p.IdUsuario,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                        Nome = p.IdUsuarioNavigation.Nome,
                        Email = p.IdUsuarioNavigation.Email,
                        Telefone = p.IdUsuarioNavigation.Telefone,
                    },
                    Crm = p.Crm,
                    Consulta = ctx.Consulta.Where(con => con.IdMedico == p.IdMedico).ToList(),
                }).ToList();

                return listaMedicos;
            }
            catch (Exception)
            { throw; }
        }
    }
}
