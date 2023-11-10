using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Requests
{
    [MessageContract]
    public class RequestBuscarRutas
    {
        [MessageHeader(Name = "Cabecera")]
        public Header header { get; set; }


        [MessageBodyMember(Name = "requestBuscarRutas")]
        public RequestBuscarRutasBody requestBuscarRutasBody { get; set; }

    }
}