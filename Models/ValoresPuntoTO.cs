using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ris_reporte_rest.Models
{
    public class ValoresPuntoTO
    {
        public String titulo { get; set; }
        public String valor { get; set; }
        public String imagen { get; set; }
        public String observaciones { get; set; }
        public String fechaInspeccion { get; set; }
        public String unidadMedida { get; set; }
        public String siglaUnidadMedida { get; set; }
    }
}