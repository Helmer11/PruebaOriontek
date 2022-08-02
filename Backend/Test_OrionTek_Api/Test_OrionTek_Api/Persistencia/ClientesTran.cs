using System;
using System.Collections.Generic;

#nullable disable

namespace Test_OrionTek_Api.Persistencia
{
    public partial class ClientesTran
    {
        public ClientesTran()
        {
            ClienteDireccionesTrans = new HashSet<ClienteDireccionesTran>();
        }

        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string ClienteTelefono { get; set; }
        public string ClienteCelular { get; set; }
        public string ClienteEmail { get; set; }

        public virtual ICollection<ClienteDireccionesTran> ClienteDireccionesTrans { get; set; }
    }
}
