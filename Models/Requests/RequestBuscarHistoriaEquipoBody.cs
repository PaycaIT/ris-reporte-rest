namespace ris_reporte_rest.Models.Requests
{
    public class RequestBuscarHistoriaEquipoBody
    {
        public long idComplejo { get; set; }
        public long idCentral { get; set; }
        public long idRuta { get; set; }
        public long idEquipo { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public bool var_critica { get; set; }
    }
}