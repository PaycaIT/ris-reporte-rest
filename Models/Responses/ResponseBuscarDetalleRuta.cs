using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Responses
{
    [MessageContract]
    public class ResponseBuscarDetalleRuta
    {
        [MessageBodyMember]
        public List<ValoresEquipoTO> listaValoresEquipo { get; set; }
    }
}