using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Requests
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