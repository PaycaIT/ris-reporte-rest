namespace ris_reporte_rest.Models
{
    public class InspeccionEquipoTO
    {
        public String fecha { get; set; }
        public InspeccionEquipoDetalleTO[] listaPuntos { get; set; }
    }
}