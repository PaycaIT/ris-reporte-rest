using System.ServiceModel;

namespace ris_reporte_rest.Models
{
    [MessageContract]
    public class RequestBuscarAlertas
    {
        [MessageHeader(Name = "Cabecera")]
        public Header header { get; set; }


        [MessageBodyMember(Name = "requestBuscarAlertas")]
        public RequestBuscarAlertasBody requestBuscarAlertas { get; set; }
    }
}