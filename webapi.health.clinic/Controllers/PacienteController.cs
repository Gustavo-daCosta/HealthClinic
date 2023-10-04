using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar operações relacionadas aos Pacientes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        /// <summary>
        /// Construtor padrão do PacienteController.
        /// </summary>
        public PacienteController() => _pacienteRepository = new PacienteRepository();

        /// <summary>
        /// Obtém uma lista de todos os pacientes.
        /// </summary>
        /// <returns>Uma lista de objetos Paciente.</returns>
        [HttpGet]
        [Route("Listar")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<Paciente> listaPacientes = _pacienteRepository.Listar();
                return Ok(listaPacientes);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém um paciente por seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do paciente.</param>
        /// <returns>O paciente correspondente ao identificador fornecido.</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [Authorize]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Paciente pacienteBuscado = _pacienteRepository.BuscarPorId(id);
                return Ok(pacienteBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém uma lista de consultas associadas a um paciente específico.
        /// </summary>
        /// <param name="id">O identificador único do paciente.</param>
        /// <returns>Uma lista de objetos Consulta.</returns>
        [HttpGet]
        [Route("ListarMinhasConsultas")]
        [Authorize]
        public IActionResult GetMyAppointment(Guid id)
        {
            try
            {
                List<Consulta> listaConsultas = _pacienteRepository.ListarMinhasConsultas(id);
                return Ok(listaConsultas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo paciente no sistema.
        /// </summary>
        /// <param name="paciente">O objeto Paciente a ser cadastrado.</param>
        /// <returns>StatusCode 201 (Created) se o cadastro for bem-sucedido.</returns>
        [HttpPost]
        [Route("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Deleta um paciente do sistema.
        /// </summary>
        /// <param name="id">O identificador único do paciente a ser deletado.</param>
        /// <returns>StatusCode 200 (OK) se a exclusão for bem-sucedida.</returns>
        [HttpDelete]
        [Route("Deletar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de um paciente existente no sistema.
        /// </summary>
        /// <param name="id">O identificador único do paciente a ser atualizado.</param>
        /// <param name="paciente">O objeto Paciente com os novos dados.</param>
        /// <returns>StatusCode 200 (OK) se a atualização for bem-sucedida.</returns>
        [HttpPut]
        [Route("Atualizar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
