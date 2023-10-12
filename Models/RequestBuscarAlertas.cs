using InterceptorSicap.cl.colbun.session.to;
using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.request
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