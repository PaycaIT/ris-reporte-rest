namespace ReporteWS.cl.colbun.sicap.to.request
{
    public class RequestBuscarAlertasBody
    {
        public long idComplejo { get; set; }
        public long idCentral { get; set; }
        public long idUsuario { get; set; }
        public long idEquipo { get; set; }
        public String fechaInicio { get; set; }
        public String fechaFin { get; set; }
    }
}