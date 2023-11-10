using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Requests
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