using empresaimpresora.Models;

namespace empresaimpresora.Servicios
{
    public interface IEmpresaService
    {
        Task<IEnumerable<Empresa>> GetEmpresasAsync();
        Task<Empresa> GetEmpresaByIdAsync(Guid id);
        Task<Empresa> AddEmpresaAsync(Empresa empresa);

    }
}