﻿namespace ReporteWS.cl.colbun.sicap.to.request
{
    public class RequestBuscarRutasBody
    {
        public long idComplejo { get; set; }
        public long idCentral { get; set; }

        public bool mant_ope { get; set; }
        public String estado { get; set; }
        public String fechaInicio { get; set; }
        public String fechaFin { get; set; }
    }
}