using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar operações relacionadas a usuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Construtor padrão que inicializa uma instância do controlador e o repositório de usuários.
        /// </summary>
        public UsuarioController() => _usuarioRepository = new UsuarioRepository();

        /// <summary>
        /// Obtém um usuário com base no e-mail e senha fornecidos.
        /// </summary>
        /// <param name="email">O endereço de e-mail do usuário.</param>
        /// <param name="senha">A senha do usuário.</param>
        /// <returns>O usuário correspondente ao e-mail e senha fornecidos.</returns>
        [HttpGet]
        [Route("BuscarPorEmailESenha")]
        [Authorize]
        public IActionResult GetByEmailAndPassword(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);
                return Ok(usuarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém um usuário com base no seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do usuário.</param>
        /// <returns>O usuário correspondente ao identificador fornecido.</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [Authorize]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                return Ok(usuarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuario">O objeto de usuário a ser cadastrado.</param>
        /// <returns>Um código de status indicando o resultado da operação.</returns>
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
