using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Requests
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