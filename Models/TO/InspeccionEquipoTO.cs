namespace ris_reporte_rest.Models.TO
{
    public class InspeccionEquipoTO
    {
        public string fecha { get; set; }
        public InspeccionEquipoDetalleTO[] listaPuntos { get; set; }
    }
}