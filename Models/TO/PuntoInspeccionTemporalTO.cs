namespace ris_reporte_rest.Models.TO
{
    public class PuntoInspeccionTemporalTO
    {
        public long idEquipo { get; set; }
        public long idEjecucionEquipo { get; set; }
        public string nombreEquipo { get; set; }
        public string codigoSAP { get; set; }
        public string imagenEquipo { get; set; }
        public string obsEquipo { get; set; }
        public long idPuntoInspeccion { get; set; }
        public long idEjecucionPunto { get; set; }
        public string referenciaFisica { get; set; }
        public string valorIngresado { get; set; }
        public string imagenPI { get; set; }
        public string obsPI { get; set; }
        public string fechaInspeccion { get; set; }
        public string unidadMedida { get; set; }
        public string siglaUnidadMedida { get; set; }

    }
}