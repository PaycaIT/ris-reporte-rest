namespace ris_reporte_rest.Models
{
    public class RequestBuscarBitacoraBody
    {
        public long idComplejo{get; set;}
        public long idCentral { get; set; }
        public String fechaInicio { get; set; }
        public String fechaFin { get; set; }
    }
}