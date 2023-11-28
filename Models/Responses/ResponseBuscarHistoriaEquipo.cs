using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Responses
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