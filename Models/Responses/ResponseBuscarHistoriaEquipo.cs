using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Responses
{
    
    public class ResponseBuscarHistoriaEquipo
    {
        
        public InspeccionEquipoTO[] listaEquipos { get; set; }

        
        public CbxTO[] listaPuntosHeader { get; set; }


    }
}