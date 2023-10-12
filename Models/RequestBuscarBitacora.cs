using InterceptorSicap.cl.colbun.session.to;
using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.request
{
    [MessageContract]
    public class RequestBuscarBitacora
    {
        [MessageHeader(Name = "Cabecera")]
        public Header header { get; set; }


        [MessageBodyMember(Name = "requestBuscarBitacora")]
        public RequestBuscarBitacoraBody requestBuscarBitacora { get; set; }
    }
}