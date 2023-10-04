using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações relacionadas a Especialidades.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        /// <summary>
        /// Construtor padrão do EspecialidadeController que inicializa o repositório de especialidades.
        /// </summary>
        public EspecialidadeController() => _especialidadeRepository = new EspecialidadeRepository();

        /// <summary>
        /// Obtém a lista de todas as especialidades.
        /// </summary>
        /// <returns>Uma lista de objetos Especialidade.</returns>
        [HttpGet]
        [Route("ListarTodos")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<Especialidade> listaEspecialidades = _especialidadeRepository.Listar();
                return Ok(listaEspecialidades);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém uma especialidade por seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único da especialidade.</param>
        /// <returns>A especialidade correspondente ao identificador fornecido.</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            try
            {
                Especialidade especialidadeBuscada = _especialidadeRepository.BuscarPorId(id);
                return Ok(especialidadeBuscada);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Cadastra uma nova especialidade.
        /// </summary>
        /// <param name="especialidade">A especialidade a ser cadastrada.</param>
        /// <returns>Um código de status indicando o resultado da operação.</returns>
        [HttpPost]
        [Route("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Deleta uma especialidade por seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único da especialidade a ser deletada.</param>
        /// <returns>Um código de status indicando o resultado da operação.</returns>
        [HttpDelete]
        [Route("Deletar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Atualiza uma especialidade por seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único da especialidade a ser atualizada.</param>
        /// <param name="especialidade">A nova informação da especialidade.</param>
        /// <returns>Um código de status indicando o resultado da operação.</returns>
        [HttpPut]
        [Route("Atualizar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Atualizar(id, especialidade);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
