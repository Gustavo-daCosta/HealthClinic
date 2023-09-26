using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IConsultaRepository
    {
        public void Cadastrar(Consulta consulta);

        public void Atualizar(Guid id, Consulta consulta);

        public List<Consulta> Listar();

        public Consulta BuscarPorId(Guid id);

        public void Deletar(Guid id);
    }
}
