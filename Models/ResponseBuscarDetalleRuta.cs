using System.ServiceModel;

namespace ris_reporte_rest.Models
{
    [MessageContract]
    public class ResponseBuscarDetalleRuta
    {
        [MessageBodyMember]
        public List<ValoresEquipoTO> listaValoresEquipo { get; set; }
    }
}