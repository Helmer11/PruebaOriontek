using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_OrionTek_Api.Interfaces;
using Test_OrionTek_Api.Persistencia;

namespace Test_OrionTek_Api.Models
{
    public class Cliente : ICliente
    {


        public List<ClientesTran> ListadoCliente()
        {
            using(var db = new TestOriontekContext())
            {
                var lista = db.ClientesTrans.ToList();

                return lista;

            }
        }


        public List<ClienteDireccionesTran> ListadoDirecciones(int cliente_id)
        {
            using(var db = new TestOriontekContext())
            {
                var detalle = db.ClienteDireccionesTrans.Where(x => x.ClienteId == cliente_id).ToList();

                return detalle;
            }
        }






    }
}
