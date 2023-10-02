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
                    prontuarioBuscado.IdClinica = prontuario.IdClinica;
                    prontuarioBuscado.IdMedico = prontuario.IdMedico;
                    prontuarioBuscado.IdPaciente = prontuario.IdPaciente;
                    prontuarioBuscado.Data = prontuario.Data;
                    prontuarioBuscado.Situacao = prontuario.Situacao;
                    prontuarioBuscado.IdClinicaNavigation = prontuario.IdClinicaNavigation;
                    prontuarioBuscado.IdMedicoNavigation = prontuario.IdMedicoNavigation;
                    prontuarioBuscado.IdPacienteNavigation = prontuario.IdPacienteNavigation;
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
                List<Prontuario> listaProntuarios = ctx.Prontuario.Select(c => new Prontuario
                {
                    IdProntuario = c.IdProntuario,
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
                    Comentarios = ctx.Comentario.Where(con => con.IdProntuario == c.IdProntuario).ToList(),
                }).ToList();

                return listaProntuarios;
            }
            catch (Exception)
            { throw; }
        }
    }
}
