﻿using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IUsuarioRepository
    {
        public void Cadastrar(Usuario usuario);

        public void Deletar(Guid id);

        public Usuario BuscarPorId(Guid id);

        public Usuario BuscarPorEmailESenha(string email, string senha);

        public List<Consulta> ListarMinhasConsultas(Guid id);
    }
}
