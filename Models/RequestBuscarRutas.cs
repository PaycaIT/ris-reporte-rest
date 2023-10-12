using InterceptorSicap.cl.colbun.session.to;
using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.request
{
    [MessageContract]
    public class RequestBuscarRutas
    {
        [MessageHeader(Name = "Cabecera")]
        public Header header { get; set; }


        [MessageBodyMember(Name = "requestBuscarRutas")]
        public RequestBuscarRutasBody requestBuscarRutasBody { get; set; }

    }
}