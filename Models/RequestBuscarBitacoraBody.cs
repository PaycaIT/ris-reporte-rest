namespace ReporteWS.cl.colbun.sicap.to.request
{
    public class RequestBuscarBitacoraBody
    {
        public long idComplejo{get; set;}
        public long idCentral { get; set; }
        public String fechaInicio { get; set; }
        public String fechaFin { get; set; }
    }
}