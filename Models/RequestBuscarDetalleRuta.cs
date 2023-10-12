using InterceptorSicap.cl.colbun.session.to;
using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.request
{
    [MessageContract]
    public class RequestBuscarDetalleRuta
    {
        [MessageHeader(Name = "Cabecera")]
        public Header header { get; set; }


        [MessageBodyMember(Name = "requestBuscarDetalleRuta")]
        public RequestBuscarDetalleRutaBody requestBuscarDetalleRutaBody { get; set; }
    }


}