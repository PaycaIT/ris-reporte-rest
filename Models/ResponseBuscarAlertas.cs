using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.response
{
    [MessageContract]
    public class ResponseBuscarAlertas
    {
        [MessageBodyMember]
        public AlertaTO[] listaAlertas { get; set; }
    }
}