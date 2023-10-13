using System.ServiceModel;

namespace ris_reporte_rest.Models
{
    [MessageContract]
    public class ResponseBuscarHistoriaEquipo
    {
        [MessageBodyMember]
        public InspeccionEquipoTO[] listaEquipos { get; set; }

        [MessageBodyMember]
        public CbxTO[] listaPuntosHeader { get; set; }


    }
}