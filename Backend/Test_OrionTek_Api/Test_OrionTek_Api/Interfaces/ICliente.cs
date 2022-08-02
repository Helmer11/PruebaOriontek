using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_OrionTek_Api.Persistencia;

namespace Test_OrionTek_Api.Interfaces
{
    interface ICliente
    {

        List<ClientesTran> ListadoCliente();
        List<ClienteDireccionesTran> ListadoDirecciones(int cliente_id);

        string setDireccion(ClienteDireccionesTran cliente);

        string setEditaDireccion(ClienteDireccionesTran cliente);

        string setDeleteDireccion(int cliente_id);

    }
}