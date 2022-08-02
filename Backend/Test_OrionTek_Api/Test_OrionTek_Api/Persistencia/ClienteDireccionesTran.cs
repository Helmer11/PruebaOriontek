using System;
using System.Collections.Generic;

#nullable disable

namespace Test_OrionTek_Api.Persistencia
{
    public partial class ClienteDireccionesTran
    {
        public int ClienteDireccionId { get; set; }
        public int ClienteId { get; set; }
        public string ClienteDireccion { get; set; }

        public virtual ClientesTran Cliente { get; set; }
    }
}
