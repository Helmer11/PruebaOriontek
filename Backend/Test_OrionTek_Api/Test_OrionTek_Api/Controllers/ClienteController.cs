using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_OrionTek_Api.Interfaces;
using Test_OrionTek_Api.Models;
using Test_OrionTek_Api.Persistencia;

namespace Test_OrionTek_Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        [Route("ListaCliente")]
        public ActionResult ListadoCliente()
        {
            ICliente cl = new Cliente();

            var lista = cl.ListadoCliente();
            return Ok(lista);
        }

        [HttpGet]
        [Route("ClienteDetalle")]
        public ActionResult detalleCliente([FromQuery] int cliente_ID)
        {
            ICliente detalle =new  Cliente();

            var deta = detalle.ListadoDirecciones(cliente_ID);

            return Ok(deta);
        }

        [HttpPost]
        [Route("DireccionAdd")]
        public ActionResult AgregarDireccion( [FromBody] ClienteDireccionesTran cliente)
        {
            ICliente detalle = new Cliente();

            var deta = detalle.setDireccion(cliente);

            return Ok(deta);
        }



        [HttpPut]
        [Route("DireccionEdita")]
        public ActionResult EditaDireccion([FromBody] ClienteDireccionesTran cliente)
        {
            ICliente detalle = new Cliente();

            var deta = detalle.setEditaDireccion(cliente);

            return Ok(deta);
        }

        [HttpGet]
        [Route("DireccionDelete")]
        public ActionResult EliminarDireccion([FromBody] int clienteID)
        {
            ICliente detalle = new Cliente();

            var deta = detalle.setDeleteDireccion(clienteID);

            return Ok(deta);
        }


    }
}
