namespace ReporteWS.cl.colbun.sicap.to.request
{
    public class RequestBuscarHistoriaEquipoBody
    {
        public long idComplejo { get; set; }
        public long idCentral { get; set; }
        public long idRuta { get; set; }
        public long idEquipo { get; set; }
        public String fechaInicio { get; set; }
        public String fechaFin { get; set; }
        public bool var_critica { get; set; }
    }
}