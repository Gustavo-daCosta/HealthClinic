using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador responsável por lidar com operações relacionadas à entidade Clinica.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// Construtor da classe ClinicaController. Inicializa o repositório de clínicas.
        /// </summary>
        public ClinicaController() => _clinicaRepository = new ClinicaRepository();

        /// <summary>
        /// Obtém a lista de todas as clínicas.
        /// </summary>
        /// <returns>Uma lista de objetos Clinica.</returns>
        [HttpGet]
        [Route("ListarTodos")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<Clinica> listaClinicas = _clinicaRepository.Listar();
                return Ok(listaClinicas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém uma clínica pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único da clínica.</param>
        /// <returns>Um objeto Clinica.</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [Authorize]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);
                return Ok(clinicaBuscada);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Cadastra uma nova clínica.
        /// </summary>
        /// <param name="clinica">A clínica a ser cadastrada.</param>
        /// <returns>StatusCode 201 se o cadastro for bem-sucedido.</returns>
        [HttpPost]
        [Route("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Deleta uma clínica pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único da clínica a ser deletada.</param>
        /// <returns>Um StatusCode Ok se a operação for bem-sucedida.</returns>
        [HttpDelete]
        [Route("Deletar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma clínica.
        /// </summary>
        /// <param name="id">O identificador único da clínica a ser atualizada.</param>
        /// <param name="clinica">Os novos dados da clínica.</param>
        /// <returns>Um StatusCode Ok se a atualização for bem-sucedida.</returns>
        [HttpPut]
        [Route("Atualizar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Clinica clinica)
        {
            try
            {
                _clinicaRepository.Atualizar(id, clinica);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
