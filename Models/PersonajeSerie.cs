using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcExamenApi1.Models
{
    public class PersonajeSerie
    {
            public int IdPersonaje { get; set; }
            
            public string Nombre { get; set; }
           
            public string Imagen { get; set; }
           
            public string Serie { get; set; }
    }
}
