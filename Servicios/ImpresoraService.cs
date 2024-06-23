using empresaimpresora.Models;
using Microsoft.EntityFrameworkCore;

namespace empresaimpresora.Servicios
{
    public class ImpresoraService: IImpresoraService
    {
        private readonly ApplicationDbcontext _context;

        public ImpresoraService(ApplicationDbcontext context){
            _context = context;
        }

        public async Task<IEnumerable<Impresora>> GetImpresoraAsync(){
            return await _context.impresoras.Include(i =>i.Empresa).ToListAsync();
        }

        public async Task<Impresora> GetImpresoraByIdAsync(Guid id){
            return await _context.impresoras.Include(i=>i.Empresa).FirstOrDefaultAsync(i =>i.ImpresoraId == id);
        }
        public async Task<Impresora> AddImpresoraAsync(Impresora impresora){
            impresora.ImpresoraId = Guid.NewGuid();
            _context.impresoras.Add(impresora);
            await _context.SaveChangesAsync();
            return impresora;
        }
        public async Task<bool> DeleteImpresoraAsync(Guid id)
        {
            var impresora = await _context.impresoras.FindAsync(id);
            if (impresora != null)
            {
                _context.impresoras.Remove(impresora);   
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}