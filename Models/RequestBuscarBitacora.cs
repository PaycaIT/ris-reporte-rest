using System.ServiceModel;

namespace ris_reporte_rest.Models
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