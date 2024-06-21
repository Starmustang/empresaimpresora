using System.Formats.Tar;
using empresaimpresora.Models;
using Microsoft.EntityFrameworkCore;

namespace empresaimpresora
{
   public class ApplicationDbcontext: DbContext
    {
       
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options): base(options) 
        {

        }
         public DbSet<Empresa> Empresas {get;set;}
        public DbSet<Impresora> impresoras {get;set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuración de la relación entre Empresa e Impresora
            List<Empresa> empresasInit = new List<Empresa>();
            empresasInit.Add(new Empresa(){EmpresaId = Guid.Parse("f83bc361-e443-47f7-89ec-556241277234"),Nombre ="WIlsoncorp", Empleados=1, Descripcion="Empresa desarrolladora de software" });
            empresasInit.Add(new Empresa(){EmpresaId = Guid.Parse("f83bc361-e443-47f7-89ec-556241277235"), Nombre ="Jdp", Empleados=8, Descripcion="Empresa desarrolladora de seguridad" });
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.impresoras)
                .WithOne(i => i.Empresa)
                .HasForeignKey(i => i.EmpresaId);
                

            modelBuilder.Entity<Empresa>(empresa =>{
                empresa.HasKey(e => e.EmpresaId);
                empresa.HasData(empresasInit);
            });
            List<Impresora> impresorasInit = new List<Impresora>();
            impresorasInit.Add(new Impresora(){ImpresoraId = Guid.Parse("f83bc361-e443-47f7-89ec-556241277236"),EmpresaId=Guid.Parse("f83bc361-e443-47f7-89ec-556241277235") ,Nombre ="Epson", Modelo="ltt3"});
            modelBuilder.Entity<Impresora>(impresora =>{
                impresora.HasKey(i => i.ImpresoraId);
                impresora.HasData(impresorasInit);
            });
        }

    }
}