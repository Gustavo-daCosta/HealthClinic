using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador para operações relacionadas a médicos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        /// <summary>
        /// Construtor padrão que inicializa uma nova instância do controlador e do repositório de médicos.
        /// </summary>
        public MedicoController() => _medicoRepository = new MedicoRepository();

        /// <summary>
        /// Obtém a lista de médicos.
        /// </summary>
        /// <returns>Uma lista de objetos Medico.</returns>
        [HttpGet]
        [Route("Listar")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<Medico> listaMedicos = _medicoRepository.Listar();
                return Ok(listaMedicos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser buscado.</param>
        /// <returns>Um objeto Medico correspondente ao ID fornecido.</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [Authorize]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Medico medicoBuscado = _medicoRepository.BuscarPorId(id);
                return Ok(medicoBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém a lista de consultas de um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico cujas consultas estão sendo buscadas.</param>
        /// <returns>Uma lista de objetos Consulta relacionados ao médico com o ID fornecido.</returns>
        [HttpGet]
        [Route("ListarMinhasConsultas")]
        [Authorize]
        public IActionResult GetMyAppointment(Guid id)
        {
            try
            {
                List<Consulta> listaConsultas = _medicoRepository.ListarMinhasConsultas(id);
                return Ok(listaConsultas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo médico.
        /// </summary>
        /// <param name="medico">O objeto Medico a ser cadastrado.</param>
        /// <returns>Um código de status 201 se o cadastro for bem-sucedido.</returns>
        [HttpPost]
        [Route("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Deleta um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser deletado.</param>
        /// <returns>Um código de status 200 se a exclusão for bem-sucedida.</returns>
        [HttpDelete]
        [Route("Deletar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser atualizado.</param>
        /// <param name="medico">O objeto Medico com os dados atualizados.</param>
        /// <returns>Um código de status 200 se a atualização for bem-sucedida.</returns>
        [HttpPut]
        [Route("Atualizar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Medico medico)
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
