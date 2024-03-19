using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace pruebaPuestoDGII.Models
{
    
        public class ComprobantesFiscales
    {
        [Key]
        public long RncCedula { get; set; }
        public required string NCF { get; set; }
        public double Monto { get; set; }
        public double Itbis18 { get; set; }
    }
}