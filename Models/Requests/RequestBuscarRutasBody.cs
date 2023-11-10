namespace ris_reporte_rest.Models.Requests
{
    public class RequestBuscarRutasBody
    {
        public long idComplejo { get; set; }
        public long idCentral { get; set; }

        public bool mant_ope { get; set; }
        public string estado { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
    }
}