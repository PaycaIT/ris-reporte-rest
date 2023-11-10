using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ris_reporte_rest.Models.TO
{
    public class ValoresPuntoTO
    {
        public string titulo { get; set; }
        public string valor { get; set; }
        public string imagen { get; set; }
        public string observaciones { get; set; }
        public string fechaInspeccion { get; set; }
        public string unidadMedida { get; set; }
        public string siglaUnidadMedida { get; set; }
    }
}