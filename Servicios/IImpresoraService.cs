using empresaimpresora.Models;

namespace empresaimpresora.Servicios
{
    public interface IImpresoraService
    {
        Task<IEnumerable<Impresora>> GetImpresoraAsync();
        Task<Impresora> GetImpresoraByIdAsync(Guid id);
        Task<Impresora> AddImpresoraAsync(Impresora impresora);
    }
}