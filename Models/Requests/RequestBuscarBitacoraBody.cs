namespace ris_reporte_rest.Models.Requests
{
    public class RequestBuscarBitacoraBody
    {
        public long idComplejo { get; set; }
        public long idCentral { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
    }
}