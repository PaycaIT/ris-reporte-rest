namespace ris_reporte_rest.Models
{
    public class RutaTO
    {

        public long idEjecucionRuta { get; set; }
        public String ruta { get; set; }
        public String usuario { get; set; }
        public String fechaInicio { get; set; }
        public String usuarioIdCierre { get; set; }
        public String fechaCierre { get; set; }
        public String fechaSincronizacion { get; set; }
        public String comentarios { get; set; }

        public int mant_ope { get; set; }
        public int cantidadEquipos { get; set; }

        public String estado { get; set; }
    }
}