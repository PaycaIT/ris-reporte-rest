using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Responses
{
    [MessageContract]
    public class ResponseBuscarAlertas
    {
        [MessageBodyMember]
        public AlertaTO[] listaAlertas { get; set; }
    }
}