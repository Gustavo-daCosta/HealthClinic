using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IComentarioRepository
    {
        public void Cadastrar(Comentario comentario);

        public void Atualizar(Guid id, Comentario comentario);

        public List<Comentario> Listar();

        public Comentario BuscarPorId(Guid id);

        public void Deletar(Guid id);
    }
}
