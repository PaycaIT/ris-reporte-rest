namespace ReporteWS.cl.colbun.sicap.to.response
{
    public class ValoresEquipoTO
    {
        public String nombreEquipo { get; set; }
        public String codigoSap { get; set; }
        public String foto { get; set; }
        public String observacion { get; set; }
        public int var_critica { get; set; }
        public List<ValoresPuntoTO> listaPuntos { get; set; }
    }
}