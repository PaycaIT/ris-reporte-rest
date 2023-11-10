using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Responses
{
    [MessageContract]
    public class ResponseBuscarBitacora
    {
        [MessageBodyMember]
        public BitacoraTO[] listaBitacora { get; set; }
    }
}