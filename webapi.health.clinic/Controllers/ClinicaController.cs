using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }
        public ClinicaController() => _clinicaRepository = new ClinicaRepository();

        [HttpGet]
        [Route("ListarTodos")]
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

        [HttpGet]
        [Route("BuscarPorId")]
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

        [HttpPost]
        [Route("Cadastrar")]
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

        [HttpDelete]
        [Route("Deletar")]
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

        [HttpPut]
        [Route("Atualizar")]
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
