using empresaimpresora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace empresaimpresora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;

        public EmpresasController(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas(){
            return await _context.Empresas.Include(e=>e.impresoras).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(Guid id){

            var empresa = await _context.Empresas.Include(e=>e.impresoras).FirstOrDefaultAsync(e=>e.EmpresaId == id);

            if (empresa == null)
            {
                return NotFound();
            }
            return empresa;
        }
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa){
            empresa.EmpresaId = Guid.NewGuid();
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpresa), new {id = empresa.EmpresaId}, empresa);
        }
    }
}