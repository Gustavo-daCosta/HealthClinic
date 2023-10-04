using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository { get; set; }
        public ProntuarioController() => _prontuarioRepository = new ProntuarioRepository();

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
