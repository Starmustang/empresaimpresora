using empresaimpresora.Models;
using empresaimpresora.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace empresaimpresora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpresorasController: ControllerBase
    {
        private readonly IImpresoraService _impresoraService;

        public ImpresorasController(IImpresoraService impresoraService){
            _impresoraService = impresoraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Impresora>>> GetImpresoras(){
            var impresoras = await _impresoraService.GetImpresoraAsync();
            return Ok(impresoras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Impresora>> GetImpresora(Guid id){

            var impresora = await _impresoraService.GetImpresoraByIdAsync(id);
            if (impresora == null)
            {
                return NotFound();
            }
            return Ok(impresora);
        }
        [HttpPost]
        public async Task<ActionResult<Impresora>> PostImpresora(Impresora impresora){
            
            var nuevaImpresora = await _impresoraService.AddImpresoraAsync(impresora);

            return CreatedAtAction(nameof(GetImpresora), new {id = nuevaImpresora.ImpresoraId}, nuevaImpresora);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImpresora(Guid id){

            var impresora = await _impresoraService.DeleteImpresoraAsync(id);

            if (!impresora)
            {
                return NotFound();
            }            
            return NoContent();
        }
    }
}