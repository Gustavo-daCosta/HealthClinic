using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IClinicaRepository
    {
        public void Cadastrar(Clinica clinica);

        public void Deletar(Guid id);

        public List<Clinica> Listar();

        public Clinica BuscarPorId(Guid id);

        public void Atualizar(Guid id, Clinica clinica);
    }
}
