namespace ris_reporte_rest.Models.TO
{
    public class ValoresEquipoTO
    {
        public string nombreEquipo { get; set; }
        public string codigoSap { get; set; }
        public string foto { get; set; }
        public string observacion { get; set; }
        public int var_critica { get; set; }
        public List<ValoresPuntoTO> listaPuntos { get; set; }
    }
}