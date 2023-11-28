using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Responses
{
    [MessageContract]
    public class ResponseBuscarRutas
    {
        [MessageBodyMember]
        public RutaTO[] listaRutas { get; set; }
    }
}