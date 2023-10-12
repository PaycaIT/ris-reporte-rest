namespace ReporteWS.cl.colbun.sicap.to.response
{
    public class PuntoInspeccionTemporalTO
    {
        public long idEquipo{get; set;}
        public long idEjecucionEquipo { get; set; }
        public String nombreEquipo{get; set;}
        public String codigoSAP{get; set;}
        public String imagenEquipo{get; set;}
        public String obsEquipo{get; set;}
        public long idPuntoInspeccion { get; set; }
        public long idEjecucionPunto { get; set; }
        public String referenciaFisica{get; set;}
        public String valorIngresado{get; set;}
        public String imagenPI{get; set;}
        public String obsPI{get; set;}
        public String fechaInspeccion { get; set; }
        public String unidadMedida { get; set; }
        public String siglaUnidadMedida { get; set; }
        
    }
}