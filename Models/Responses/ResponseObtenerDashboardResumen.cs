using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Responses
{
    public class ResponseObtenerDashboardResumen
    {
        public int cantidadAnomalias { get; set; }
        public int cantidadRutasEjecutadas { get; set; }
        public int cantidadEquiposInspeccionados { get; set; }
        public int cantidadAlertasEnviadas { get; set; }



    }
}
