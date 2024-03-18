using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public long RncCedula;
        public required string NCF;
        public double Monto;
        public double Itbis18;
    }

    [ApiController]
    [Route("[controller]")]

    public class Contribuyentes : ControllerBase
    {
        object listaContribuyente = new List<Contribuyente>()
        {
            new Contribuyente() {RncCedula = 98754321012, Nombre = "JUAN PEREZ", Tipo = "PERSONA FISICA", Estatus = "inactivo"},
            new Contribuyente() {RncCedula = 99754321012, Nombre = "PEDRO DURAN", Tipo = "PERSONA FISICA", Estatus = "inactivo"},
            new Contribuyente() {RncCedula = 99954321012, Nombre = "JOSE SANTANA", Tipo = "PERSONA FISICA", Estatus = "activo"},
            new Contribuyente() {RncCedula = 99999321012, Nombre = "GEORGE JIMENEZ", Tipo = "PERSONA FISICA", Estatus = "inactivo"},
            new Contribuyente() {RncCedula = 99999921012, Nombre = "SOCRATES TAVAREZ", Tipo = "PERSONA FISICA", Estatus = "activo"},
            new Contribuyente() {RncCedula = 99999999012, Nombre = "ALBERTO POLANCO", Tipo = "PERSONA FISICA", Estatus = "activo"},
            new Contribuyente() {RncCedula = 99999999912, Nombre = "JULIAN RODRIGUEZ", Tipo = "PERSONA FISICA", Estatus = "inactivo"}
        };

        // Metodo para Obtener Lista de Contribuyentes
        [HttpGet("GetListadoContribuyentes")]
        public ActionResult<List<Contribuyente>> Get()
        {
            return Ok(listaContribuyente);
        }


        // Metodo para Obtener Comprobantes Fiscales

        [HttpGet("GetListadoComprobastesFiscales/{RncOCedula}")]
        public ActionResult<List<ComprobantesFiscales>> Get(long rncCed)
        {

            var listaComprobastesFiscales = new List<ComprobantesFiscales>()
            {
                new ComprobantesFiscales() {RncCedula = 98754321012, NCF = "E310000000001", Monto = 200, Itbis18 = 36},
                new ComprobantesFiscales() {RncCedula = 98754321012, NCF = "E310000000002", Monto = 1000, Itbis18 = 180},
                new ComprobantesFiscales() {RncCedula = 99754321012, NCF = "E320000000001", Monto = 300, Itbis18 = 46},
                new ComprobantesFiscales() {RncCedula = 99754321012, NCF = "E320000000002", Monto = 2000, Itbis18 = 250},
                new ComprobantesFiscales() {RncCedula = 99954321012, NCF = "E330000000001", Monto = 100, Itbis18 = 80},
                new ComprobantesFiscales() {RncCedula = 99954321012, NCF = "E330000000002", Monto = 500, Itbis18 = 120},
                new ComprobantesFiscales() {RncCedula = 99999321012, NCF = "E340000000001", Monto = 350, Itbis18 = 90},
                new ComprobantesFiscales() {RncCedula = 99999321012, NCF = "E340000000002", Monto = 800, Itbis18 = 110},

            };

            var buscados = new List<ComprobantesFiscales>();
            foreach (var comprobante in listaComprobastesFiscales)
            {
                if (comprobante.RncCedula == rncCed)
                {
                    buscados.Add(comprobante);
                }
            };

            return buscados;
        }
    }
}

