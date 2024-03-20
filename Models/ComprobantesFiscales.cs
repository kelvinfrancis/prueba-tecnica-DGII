using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace pruebaPuestoDGII.Models
{
    
        public class ComprobantesFiscales
    {
        
        public long RncCedula { get; set; }
        [Key]
        public required string NCF { get; set; }
        public double Monto { get; set; }
        public double Itbis18 { get; set; }
    }
}