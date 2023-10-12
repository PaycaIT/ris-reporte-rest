using System.ServiceModel;

namespace ReporteWS.cl.colbun.sicap.to.response
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