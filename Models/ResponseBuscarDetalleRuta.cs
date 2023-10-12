using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.response
{
    [MessageContract]
    public class ResponseBuscarDetalleRuta
    {
        [MessageBodyMember]
        public List<ValoresEquipoTO> listaValoresEquipo { get; set; }
    }
}