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
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository { get; set; }
        public ComentarioController() => _comentarioRepository = new ComentarioRepository();

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
