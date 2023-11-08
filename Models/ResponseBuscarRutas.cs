using System.ServiceModel;

namespace ris_reporte_rest.Models
{
    [MessageContract]
    public class ResponseBuscarRutas
    {
        [MessageBodyMember]
        public RutaTO[] listaRutas { get; set; }
    }
}