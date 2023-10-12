using InterceptorSicap.cl.colbun.session.to;
using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.request
{
    [MessageContract]
    public class RequestBuscarHistoriaEquipo
    {
        [MessageHeader(Name = "Cabecera")]
        public Header header { get; set; }


        [MessageBodyMember(Name = "requestBuscarHistoriaEquipo")]
        public RequestBuscarHistoriaEquipoBody requestBuscarHistoriaEquipoBody { get; set; }
    }
}