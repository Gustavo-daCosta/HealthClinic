using webapi.health.clinic.Context;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext ctx;
        public PacienteRepository() => ctx = new HealthClinicContext();

        public void Atualizar(Guid id, Paciente paciente)
        {
            try
            {
                Paciente pacienteBuscado = BuscarPorId(id);

                if (pacienteBuscado != null)
                {
                    pacienteBuscado.IdUsuario = paciente.IdUsuario;
                    pacienteBuscado.Cpf = paciente.Cpf;
                    pacienteBuscado.DataNascimento = paciente.DataNascimento;
                    pacienteBuscado.Consulta = paciente.Consulta;
                    pacienteBuscado.IdUsuarioNavigation = paciente.IdUsuarioNavigation;
                    ctx.Paciente.Update(pacienteBuscado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                Paciente pacienteBuscado = Listar().FirstOrDefault(c => c.IdPaciente == id)!;
                return pacienteBuscado;
            }
            catch (Exception)
            { throw; }
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                ctx.Paciente.Add(paciente);
                ctx.SaveChanges();
            }
            catch (Exception)
            { throw; }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Paciente pacienteBuscado = BuscarPorId(id);
                if (pacienteBuscado != null)
                {
                    ctx.Paciente.Remove(pacienteBuscado);
                    ctx.SaveChanges();
                }
                return;
            }
            catch (Exception)
            { throw; }
        }

        public List<Paciente> Listar()
        {
            try
            {
                List<Paciente> listaPacientes = ctx.Paciente.Select(p => new Paciente
                {
                    IdPaciente = p.IdPaciente,
                    IdUsuario = p.IdUsuario,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                        Nome = p.IdUsuarioNavigation.Nome,
                        Email = p.IdUsuarioNavigation.Email,
                        Telefone = p.IdUsuarioNavigation.Telefone,
                    },
                    Cpf = p.Cpf,
                    DataNascimento = p.DataNascimento,
                    Consulta = ctx.Consulta.Where(con => con.IdPaciente == p.IdPaciente).ToList(),
                }).ToList();

                return listaPacientes;
            }
            catch (Exception)
            { throw; }
        }

        public List<Consulta> ListarMinhasConsultas(Guid id)
        {
            try
            {
                List<Consulta> listaConsultas =  ctx.Consulta.Where(u => u.IdPaciente == id).Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    Data = c.Data,
                    IdMedico = c.IdMedico,
                    IdPaciente = c.IdPaciente,
                    IdClinica = c.IdClinica,
                    IdMedicoNavigation = new Medico
                    {
                        IdMedico = c.IdMedicoNavigation!.IdMedico,
                        Crm = c.IdMedicoNavigation.Crm,
                    },
                    IdPacienteNavigation = new Paciente
                    {
                        IdPaciente = c.IdPacienteNavigation!.IdPaciente,
                        Cpf = c.IdPacienteNavigation!.Cpf,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                    },
                    IdClinicaNavigation = new Clinica
                    {
                        IdClinica = c.IdClinicaNavigation!.IdClinica,
                        RazaoSocial = c.IdClinicaNavigation.RazaoSocial,
                        Endereco = c.IdClinicaNavigation.Endereco,
                        HoraAbertura = c.IdClinicaNavigation.HoraAbertura,
                        HoraEncerramento = c.IdClinicaNavigation.HoraEncerramento,
                    }
                }).ToList();

                return listaConsultas;
            }
            catch (Exception)
            {
                throw;
            };
        }
    }
}
