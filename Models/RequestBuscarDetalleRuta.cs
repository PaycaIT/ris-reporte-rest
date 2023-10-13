using System.ServiceModel;

namespace ris_reporte_rest.Models
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