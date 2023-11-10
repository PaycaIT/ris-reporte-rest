namespace ris_reporte_rest.Models.Requests
{
    public class RequestBuscarAlertasBody
    {
        public long idComplejo { get; set; }
        public long idCentral { get; set; }
        public long idUsuario { get; set; }
        public long idEquipo { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
    }
}