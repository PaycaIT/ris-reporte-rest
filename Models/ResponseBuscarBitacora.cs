using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.response
{
    [MessageContract]
    public class ResponseBuscarBitacora
    {
        [MessageBodyMember]
        public BitacoraTO[] listaBitacora { get; set; }
    }
}