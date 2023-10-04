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
    /// Controlador responsável pelas operações relacionadas aos prontuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository { get; set; }

        /// <summary>
        /// Construtor padrão que inicializa o repositório de prontuários.
        /// </summary>
        public ProntuarioController() => _prontuarioRepository = new ProntuarioRepository();

        /// <summary>
        /// Obtém a lista de todos os prontuários.
        /// </summary>
        /// <returns>Uma lista de prontuários ou uma mensagem indicando que nenhum prontuário foi encontrado.</returns>
        [HttpGet]
        [Route("Listar")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<Prontuario> listaProntuarios = _prontuarioRepository.Listar();
                return Ok(listaProntuarios.IsNullOrEmpty() ? "Nenhum prontuário foi encontrado." : listaProntuarios);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém um prontuário pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do prontuário.</param>
        /// <returns>O prontuário encontrado ou uma mensagem indicando que nenhum prontuário foi encontrado.</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [Authorize]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Prontuario prontuarioBuscado = _prontuarioRepository.BuscarPorId(id);
                return Ok(prontuarioBuscado == null ? "Prontuário não encontrado." : prontuarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo prontuário.
        /// </summary>
        /// <param name="prontuario">O objeto Prontuario a ser cadastrado.</param>
        /// <returns>Status 201 Created em caso de sucesso.</returns>
        [HttpPost]
        [Route("Cadastrar")]
        [Authorize(Roles = "Médico")]
        public IActionResult Post(Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Cadastrar(prontuario);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Deleta um prontuário pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do prontuário a ser deletado.</param>
        /// <returns>Status 200 OK em caso de sucesso.</returns>
        [HttpDelete]
        [Route("Deletar")]
        [Authorize(Roles = "Médico")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _prontuarioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Atualiza um prontuário pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do prontuário a ser atualizado.</param>
        /// <param name="prontuario">O objeto Prontuario atualizado.</param>
        /// <returns>Status 200 OK em caso de sucesso.</returns>
        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Put(Guid id, Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Atualizar(id, prontuario);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
