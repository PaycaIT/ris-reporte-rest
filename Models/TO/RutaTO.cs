namespace ris_reporte_rest.Models.TO
{
    public class RutaTO
    {

        public long idEjecucionRuta { get; set; }
        public string ruta { get; set; }
        public string usuario { get; set; }
        public string fechaInicio { get; set; }
        public string usuarioIdCierre { get; set; }
        public string fechaCierre { get; set; }
        public string fechaSincronizacion { get; set; }
        public string comentarios { get; set; }

        public int mant_ope { get; set; }
        public int cantidadEquipos { get; set; }

        public string estado { get; set; }
    }
}