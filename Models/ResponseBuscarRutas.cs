using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.response
{
    [MessageContract]
    public class ResponseBuscarRutas
    {
        [MessageBodyMember]
        public RutaTO[] listaRutas { get; set; }
    }
}