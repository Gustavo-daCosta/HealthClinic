using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas a Consultas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// Construtor padrão do ConsultaController que inicializa o repositório de consultas.
        /// </summary>
        public ConsultaController() => _consultaRepository = new ConsultaRepository();

        /// <summary>
        /// Obtém a lista de todas as consultas.
        /// </summary>
        /// <returns>Lista de consultas.</returns>
        [HttpGet]
        [Route("Listar")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<Consulta> listaConsultas = _consultaRepository.Listar();
                return Ok(listaConsultas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Obtém uma consulta pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único da consulta.</param>
        /// <returns>A consulta encontrada.</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [Authorize]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);
                return Ok(consultaBuscada);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Cadastra uma nova consulta.
        /// </summary>
        /// <param name="consulta">Consulta a ser cadastrada.</param>
        /// <returns>Código de status indicando o resultado da operação.</returns>
        [HttpPost]
        [Route("Cadastrar")]
        [Authorize("Administrador")]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Deleta uma consulta pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único da consulta a ser deletada.</param>
        /// <returns>Código de status indicando o resultado da operação.</returns>
        [HttpDelete]
        [Route("Deletar")]
        [Authorize("Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Atualiza uma consulta pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único da consulta a ser atualizada.</param>
        /// <param name="consulta">Nova informação da consulta.</param>
        /// <returns>Código de status indicando o resultado da operação.</returns>
        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Put(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
