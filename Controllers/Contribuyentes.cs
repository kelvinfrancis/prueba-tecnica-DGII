using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaPuestoDGII.Data;
using pruebaPuestoDGII.Models;
using SQLitePCL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaPuestoDGII.Controllers
{
    public class Contribuyente
    {
        public long RncCedula { get; set; }
        public required string Nombre { get; set; }
        public required string Tipo { get; set; }
        public required string Estatus { get; set; }
    }

    public class ComprobantesFiscales
    {
        public long RncCedula { get; set; }
        public required string NCF { get; set; }
        public double Monto { get; set; }
        public double Itbis18 { get; set; }
    }

    [ApiController]
    [Route("[controller]")]

    public class Contribuyentes : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<Contribuyentes> _logger;

        public Contribuyentes(DataContext context, ILogger<Contribuyentes> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Metodo para Obtener Lista de Contribuyentes
        [HttpGet("GetListadoContribuyentes")]
        public async Task<ActionResult<List<Contribuyente>>> Get()
        {
            var listaContribuyentes = await _context.Contribuyente.ToListAsync();
            return Ok(listaContribuyentes);
        }


        // Metodo para Obtener Comprobantes Fiscales
        [HttpGet("GetListadoComprobastesFiscales/{RncOCedula}")]
        public async Task<ActionResult<List<ComprobantesFiscales>>> Get(long RncOCedula)
        {
            var listaComprobastesFiscales = await _context.ComprobantesFiscales.ToListAsync();
            var buscados = new List<Models.ComprobantesFiscales>();
            foreach (var comprobante in listaComprobastesFiscales)
            {
                if (comprobante.RncCedula == RncOCedula)
                {
                    buscados.Add(comprobante);
                }
            };
            return Ok(buscados);
        }
    }
}

