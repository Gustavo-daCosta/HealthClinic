using webapi.health.clinic.Context;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext ctx;
        public ConsultaRepository() => ctx = new HealthClinicContext();

        public void Atualizar(Guid id, Consulta consulta)
        {
            try
            {
                Consulta consultaBuscada = BuscarPorId(id);

                if (consultaBuscada != null)
                {
                    consultaBuscada.IdClinica = consulta.IdClinica;
                    consultaBuscada.IdMedico = consulta.IdMedico;
                    consultaBuscada.IdPaciente = consulta.IdPaciente;
                    consultaBuscada.Data = consulta.Data;
                    consultaBuscada.Situacao = consulta.Situacao;
                    consultaBuscada.IdClinicaNavigation = consulta.IdClinicaNavigation;
                    consultaBuscada.IdMedicoNavigation = consulta.IdMedicoNavigation;
                    consultaBuscada.IdPacienteNavigation = consulta.IdPacienteNavigation;
                    ctx.Consulta.Update(consultaBuscada);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                Consulta consultaBuscada = Listar().FirstOrDefault(c => c.IdConsulta == id)!;
                return consultaBuscada;
            }
            catch (Exception)
            { throw; }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                ctx.Consulta.Add(consulta);
                ctx.SaveChanges();
            }
            catch (Exception)
            { throw; }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Consulta consultaBuscada = BuscarPorId(id);
                if (consultaBuscada != null)
                {
                    ctx.Consulta.Remove(consultaBuscada);
                    ctx.SaveChanges();
                }
                return;
            }
            catch (Exception)
            { throw; }
        }

        public List<Consulta> Listar()
        {
            try
            {
                List<Consulta> listaConsultas = ctx.Consulta.Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    IdClinica = c.IdClinica,
                    IdMedico = c.IdMedico,
                    IdPaciente = c.IdPaciente,
                    Data = c.Data,
                    Situacao = c.Situacao,
                    IdClinicaNavigation = new Clinica
                    {
                        IdClinica = c.IdClinicaNavigation.IdClinica,
                        RazaoSocial = c.IdClinicaNavigation.RazaoSocial,
                        Endereco = c.IdClinicaNavigation.Endereco,
                        Cnpj = c.IdClinicaNavigation.Cnpj,
                        HoraAbertura = c.IdClinicaNavigation.HoraAbertura,
                        HoraEncerramento = c.IdClinicaNavigation.HoraEncerramento,
                    },
                    IdMedicoNavigation = new Medico
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        Crm = c.IdMedicoNavigation.Crm,
                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario,
                            IdTipoUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.IdTipoUsuario,
                            Nome = c.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                            Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email,
                            Telefone = c.IdMedicoNavigation.IdUsuarioNavigation.Telefone,
                            IdTipoUsuarioNavigation = c.IdMedicoNavigation.IdUsuarioNavigation.IdTipoUsuarioNavigation,
                        }
                    },
                    IdPacienteNavigation = new Paciente
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        IdUsuario = c.IdPacienteNavigation.IdUsuario,
                        Cpf = c.IdPacienteNavigation.Cpf,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario,
                            IdTipoUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.IdTipoUsuario,
                            Nome = c.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                            Email = c.IdPacienteNavigation.IdUsuarioNavigation.Email,
                            Telefone = c.IdPacienteNavigation.IdUsuarioNavigation.Telefone,
                            IdTipoUsuarioNavigation = c.IdPacienteNavigation.IdUsuarioNavigation.IdTipoUsuarioNavigation,
                        }
                    },
                    Comentarios = ctx.Comentario.Where(con => con.IdConsulta == c.IdConsulta).ToList(),
                }).ToList();

                return listaConsultas;
            }
            catch (Exception)
            { throw; }
        }
    }
}
