using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IMedicoRepository
    {
        public void Cadastrar(Medico medico);

        public void Atualizar(Guid id, Medico medico);

        public List<Medico> Listar();

        public Medico BuscarPorId(Guid id);

        public void Deletar(Guid id);

        public List<Consulta> ListarMinhasConsultas(Guid id);
    }
}
