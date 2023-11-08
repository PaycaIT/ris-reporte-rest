using System.ServiceModel;

namespace ris_reporte_rest.Models
{
    [MessageContract]
    public class ResponseBuscarAlertas
    {
        [MessageBodyMember]
        public AlertaTO[] listaAlertas { get; set; }
    }
}