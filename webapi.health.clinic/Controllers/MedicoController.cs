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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }
        public MedicoController() => _medicoRepository = new MedicoRepository();

        [HttpGet]
        [Route("Listar")]
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
    }
}
