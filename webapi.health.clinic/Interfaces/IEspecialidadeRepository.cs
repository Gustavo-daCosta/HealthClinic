using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IEspecialidadeRepository
    {
        public void Cadastrar(Especialidade especialidade);

        public void Atualizar(Guid id, Especialidade especialidade);

        public List<Especialidade> Listar();

        public Especialidade BuscarPorId(Guid id);

        public void Deletar(Guid id);
    }
}
