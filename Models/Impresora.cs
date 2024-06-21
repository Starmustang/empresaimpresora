namespace empresaimpresora.Models
{
   public class Impresora
    {
        public Guid ImpresoraId {get;set;}

        public string Nombre {get;set;}

        public string Modelo {get;set;}

        public Guid EmpresaId {get;set;}

        public virtual Empresa Empresa {get;set;}

    }

/*Te voy a poner una prueba. Cuando termines me mandas el repo de git 

Tienes 2 dias para entregarme una Api en .net 6 o superior, donde: se registre una empresa y se registren impresoras, cada empresa tendra una lista de impresoras que hayan rentado. 

Necesito que apliques: 
Librerias como: 
* EntityFramework (Los id deben ser guid y no int)

Patrones de diseño como :
* Inyeccion de dependencias
* MVC*/
}