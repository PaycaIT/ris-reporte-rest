using System.ServiceModel;

namespace ris_reporte_rest.Models.TO
{
    [MessageContract]
    public class Header
    {
        public string token { get; set; }

        public string codigoUsuario { get; set; }
    }
}
