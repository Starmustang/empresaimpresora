using empresaimpresora.Models;
using empresaimpresora.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace empresaimpresora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _empresaservice;

        public EmpresasController(IEmpresaService empresaservice)
        {
            _empresaservice = empresaservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas(){
            var empresas = await _empresaservice.GetEmpresasAsync();
            return Ok(empresas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(Guid id){

            var empresa = await _empresaservice.GetEmpresaByIdAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa){
            
            var nuevaEmpresa = await _empresaservice.AddEmpresaAsync(empresa);
            return CreatedAtAction(nameof(GetEmpresa), new {id = nuevaEmpresa.EmpresaId}, nuevaEmpresa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Empresa>> DeleteEmpresa(Guid id){

            var empresa = await _empresaservice.DeleteEmpresaAsync(id);

            if (!empresa)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}