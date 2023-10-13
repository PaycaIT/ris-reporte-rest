using System.ServiceModel;

namespace ris_reporte_rest.Models
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