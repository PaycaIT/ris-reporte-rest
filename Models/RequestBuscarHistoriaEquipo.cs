using System.ServiceModel;

namespace ris_reporte_rest.Models
{
    [MessageContract]
    public class RequestBuscarHistoriaEquipo
    {
        [MessageHeader(Name = "Cabecera")]
        public Header header { get; set; }


        [MessageBodyMember(Name = "requestBuscarHistoriaEquipo")]
        public RequestBuscarHistoriaEquipoBody requestBuscarHistoriaEquipoBody { get; set; }
    }
}