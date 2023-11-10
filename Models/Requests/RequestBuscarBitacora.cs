﻿using System.ServiceModel;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Models.Requests
{
    [MessageContract]
    public class RequestBuscarBitacora
    {
        [MessageHeader(Name = "Cabecera")]
        public Header header { get; set; }


        [MessageBodyMember(Name = "requestBuscarBitacora")]
        public RequestBuscarBitacoraBody requestBuscarBitacora { get; set; }
    }
}