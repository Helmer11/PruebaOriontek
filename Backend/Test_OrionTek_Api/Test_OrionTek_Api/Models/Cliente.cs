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

        public string setDireccion(ClienteDireccionesTran cliente)
        {

            try
            {

                using (var db = new TestOriontekContext())
                {
                    ClienteDireccionesTran sd = new ClienteDireccionesTran()
                    {
                        ClienteId = cliente.ClienteId,
                        ClienteDireccion = cliente.ClienteDireccion,
                    };

                    db.ClienteDireccionesTrans.Add(sd);
                    db.SaveChanges();

                    return "1";
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.InnerException.Message);
                return "Error. A la hora de agregar la direccion";
            }

        }

        public string setEditaDireccion(ClienteDireccionesTran cliente)
        {

            try
            {

                using (var db = new TestOriontekContext())
                {
                    
                    db.ClienteDireccionesTrans.Attach(cliente);
                    var regi = db.Entry(cliente);
                    regi.Property(x => x.ClienteDireccion).IsModified = true;
                    db.SaveChanges();

                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "Error. A la hora de agregar la direccion";
            }



        }


        public string setDeleteDireccion(int cliente_id)
        {

            try
            {

                using (var db = new TestOriontekContext())
                {

                    var dele = db.ClienteDireccionesTrans.Where(x => x.ClienteId == cliente_id).FirstOrDefault();

                    db.ClienteDireccionesTrans.RemoveRange(dele);
                    db.SaveChanges();

                    return "1";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "Error. A la hora de eliminar la direccion";
            }



        }




    }
}
