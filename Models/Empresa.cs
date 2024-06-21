using System.Text.Json.Serialization;

namespace empresaimpresora.Models
{
   public class Empresa
    {
        public Guid EmpresaId {get;set;}

        public string Nombre {get;set;}

        public string Descripcion {get;set;}

        public int Empleados {get;set;}        

        [JsonIgnore]
        public ICollection<Impresora> impresoras {get;set;} = new List<Impresora>();

    }
}