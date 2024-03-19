
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace pruebaPuestoDGII.Models
{
    
    public class Contribuyente
    {
        [Key]
        public long RncCedula { get; set; }
        public required string Nombre { get; set; }
        public required string Tipo { get; set; }
        public required string Estatus { get; set; }
    }
}
