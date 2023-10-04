using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador responsável por operações relacionadas a comentários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository { get; set; }

        /// <summary>
        /// Construtor padrão que inicializa uma instância do controlador ComentarioController.
        /// </summary>
        public ComentarioController() => _comentarioRepository = new ComentarioRepository();

        /// <summary>
        /// Obtém uma lista de todos os comentários.
        /// </summary>
        /// <returns>Uma lista de comentários ou uma mensagem indicando que nenhum prontuário foi encontrado.</returns>
        [HttpGet]
        [Route("Listar")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<Comentario> listaComentarios = _comentarioRepository.Listar();
                return Ok(listaComentarios.IsNullOrEmpty() ? "Nenhum prontuário foi encontrado." : listaComentarios);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém um comentário pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do comentário.</param>
        /// <returns>O comentário encontrado ou uma mensagem indicando que o prontuário não foi encontrado.</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [Authorize]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Comentario comentarioBuscado = _comentarioRepository.BuscarPorId(id);
                return Ok(comentarioBuscado == null ? "Prontuário não encontrado." : comentarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo comentário.
        /// </summary>
        /// <param name="comentario">O objeto Comentario a ser cadastrado.</param>
        /// <returns>Um status code 201 se o cadastro for bem-sucedido.</returns>
        [HttpPost]
        [Route("Cadastrar")]
        [Authorize(Roles = "Paciente")]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(comentario);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Deleta um comentário pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do comentário a ser deletado.</param>
        /// <returns>Um status code 200 se a operação for bem-sucedida.</returns>
        [HttpDelete]
        [Route("Deletar")]
        [Authorize(Roles = "Paciente")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Atualiza um comentário pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do comentário a ser atualizado.</param>
        /// <param name="comentario">O objeto Comentario com os dados atualizados.</param>
        /// <returns>Um status code 200 se a atualização for bem-sucedida.</returns>
        [HttpPut]
        [Route("Atualizar")]
        [Authorize(Roles = "Paciente")]
        public IActionResult Put(Guid id, Comentario comentario)
        {
            try
            {
                _comentarioRepository.Atualizar(id, comentario);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
