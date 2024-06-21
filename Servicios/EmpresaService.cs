using empresaimpresora.Models;
using Microsoft.EntityFrameworkCore;

namespace empresaimpresora.Servicios
{
    public class EmpresaService: IEmpresaService
    {
        private readonly ApplicationDbcontext _context;

        public EmpresaService(ApplicationDbcontext context){
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> GetEmpresasAsync(){
            return await _context.Empresas.Include(e =>e.impresoras).ToListAsync();
        }

        public async Task<Empresa> GetEmpresaByIdAsync(Guid id){
            return await _context.Empresas.Include(e =>e.impresoras).FirstOrDefaultAsync(e =>e.EmpresaId == id);
        }

        public async Task<Empresa> AddEmpresaAsync(Empresa empresa){

            empresa.EmpresaId = Guid.NewGuid();
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }
    }
}