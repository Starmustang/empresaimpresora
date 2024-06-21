using empresaimpresora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace empresaimpresora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpresorasController: ControllerBase
    {
        private readonly ApplicationDbcontext _context;

        public ImpresorasController(ApplicationDbcontext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Impresora>>> GetImpresoras(){
            return await _context.impresoras.Include(i =>i.Empresa).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Impresora>> GetImpresora(Guid id){

            var impresora = await _context.impresoras.Include(i =>i.Empresa).FirstOrDefaultAsync(i =>i.ImpresoraId == id);

            if (impresora == null)
            {
                return NotFound();
            }
            return impresora;
        }
        [HttpPost]
        public async Task<ActionResult<Impresora>> PostImpresora(Impresora impresora){
            impresora.ImpresoraId = Guid.NewGuid();
            _context.impresoras.Add(impresora);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetImpresora), new {id = impresora.ImpresoraId});
        }
    }
}