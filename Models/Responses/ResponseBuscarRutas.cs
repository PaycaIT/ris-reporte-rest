using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Responses
{
    
    public class ResponseBuscarRutas
    {
        
        public List<RutaTO> listaRutas { get; set; }
    }
}