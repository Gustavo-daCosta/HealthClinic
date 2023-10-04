using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IPacienteRepository
    {
        public void Cadastrar(Paciente paciente);

        public void Atualizar(Guid id, Paciente paciente);

        public List<Paciente> Listar();

        public Paciente BuscarPorId(Guid id);

        public void Deletar(Guid id);

        public List<Consulta> ListarMinhasConsultas(Guid id);
    }
}
