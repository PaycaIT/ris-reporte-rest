using System.ServiceModel;

namespace ris_reporte_rest.Models
{
    [MessageContract]
    public class ResponseBuscarBitacora
    {
        [MessageBodyMember]
        public BitacoraTO[] listaBitacora { get; set; }
    }
}