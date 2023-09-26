using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IProntuarioRepository
    {
        public void Cadastrar(Prontuario prontuario);

        public void Atualizar(Guid id, Prontuario prontuario);

        public List<Prontuario> Listar();

        public Prontuario BuscarPorId(Guid id);

        public void Deletar(Guid id);
    }
}
