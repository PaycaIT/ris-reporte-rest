using Dapper;
using ris_reporte_rest.DataAccess;
using ris_reporte_rest.Models;
using System.Data;

namespace ris_reporte_rest.DAO
{
    public class ReporteDao
    {
        private readonly IDapper _dapper;
        public ReporteDao(IDapper dapper)
        {
            _dapper = dapper;
        }

        public BitacoraTO[] buscarBitacora(RequestBuscarBitacoraBody request)
        {
            const string SP = "[dbo].[prc_obtieneReporteBitacoras]";
            DynamicParameters dbParam = new DynamicParameters();
            dbParam.Add("@i_id_complejo", request.idComplejo);
            dbParam.Add("@i_id_central", request.idCentral);
            dbParam.Add("@i_fecha_inicio", request.fechaInicio + " 00:00:00");
            dbParam.Add("@i_fecha_fin", request.fechaFin + " 23:59:59");
            BitacoraTO[] result = _dapper.GetAll<BitacoraTO>(SP, dbParam, commandType: CommandType.StoredProcedure).ToArray();
            return result;
        }

        public RutaTO[] buscarRutas(RequestBuscarRutasBody request)
        {
            const string SP = "[dbo].[prc_obtieneReporteRutas]";
            var dbParam = new DynamicParameters();
            dbParam.Add("@i_id_complejo", request.idComplejo);
            dbParam.Add("@i_id_central", request.idCentral);
            dbParam.Add("@i_fecha_inicio", request.fechaInicio + " 00:00:00");
            dbParam.Add("@i_fecha_fin", request.fechaFin + " 23:59:59");
            dbParam.Add("@i_mant_ope", request.mant_ope);

            if (string.IsNullOrWhiteSpace(request.estado))
            {
                dbParam.Add("@i_estado", DBNull.Value);
            }
            else
            {
                dbParam.Add("@i_estado", request.estado);
            }

            RutaTO[] result = _dapper.GetAll<RutaTO>(SP, dbParam, commandType: CommandType.StoredProcedure).ToArray();

            // Ahora, procesa el estado y asigna valores deseados
            foreach (RutaTO rutaTO in result)
            {
                string estado = rutaTO.estado;
                if ("INI".Equals(estado))
                {
                    rutaTO.estado = "Iniciada";
                }
                else if ("SIN".Equals(estado))
                {
                    rutaTO.estado = "Sincronizada";
                }
                else if ("DES".Equals(estado))
                {
                    rutaTO.estado = "Descartada";
                }
                else
                {
                    rutaTO.estado = "Sin Estado";
                }
            }

            return result;
        }


        private InspeccionEquipoDetalleTO[] cargarPuntosToEquipo(CbxTO[] listaPuntos)
        {
            InspeccionEquipoDetalleTO[] listaPuntoEquipoTO = new InspeccionEquipoDetalleTO[listaPuntos.Length];

            for (int i = 0; i < listaPuntos.Length; i++)
            {
                InspeccionEquipoDetalleTO inspeccionPuntoTO = new InspeccionEquipoDetalleTO();
                inspeccionPuntoTO.idPunto = listaPuntos[i].id;
                listaPuntoEquipoTO[i] = inspeccionPuntoTO;
            }

            return listaPuntoEquipoTO;
        }

        private CbxTO[] obtieneListaCbxPuntoInspeccion(long idEquipo)
        {
            const string SP = "[dbo].[prc_obtieneListaCbxPI]";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@i_idEquipo", idEquipo);
            parameters.Add("@i_sinAsignar", "0");
            parameters.Add("@i_idCentral", "0");
            List<CbxPI> listaCbxPI = _dapper.GetAll<CbxPI>(SP, parameters, commandType: CommandType.StoredProcedure);

            // Agregar la lógica para asignar valores a la propiedad 'nombre' de CbxTO
            CbxTO[] listaCbxFinal = new CbxTO[listaCbxPI.Count];
            for (int i = 0; i < listaCbxPI.Count; i++)
            {
                CbxTO cbxTO = new CbxTO();
                cbxTO.id = listaCbxPI[i].idPuntoInspeccion;
                string referenciaFisica = listaCbxPI[i].referenciaFisica;
                string sigla = listaCbxPI[i].sigla;
                cbxTO.nombre = referenciaFisica + " (" + sigla + ")";
                listaCbxFinal[i] = cbxTO;
            }

            return listaCbxFinal;
        }

        public AlertaTO[] buscarAlertas(RequestBuscarAlertasBody request)
        {
            const string SP = "[dbo].[prc_obtieneReporteAlertas]";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@i_id_complejo", request.idComplejo);
            parameters.Add("@i_id_central", request.idCentral);
            parameters.Add("@i_id_usuario", request.idUsuario);
            parameters.Add("@i_id_equipo", request.idEquipo);
            parameters.Add("@i_fecha_inicio", request.fechaInicio + " 00:00:00");
            parameters.Add("@i_fecha_fin", request.fechaFin + " 23:59:59");
            AlertaTO[] result = _dapper.GetAll<AlertaTO>(SP, parameters, commandType: CommandType.StoredProcedure).ToArray();
            return result;
        }

        public ResponseBuscarDetalleRuta buscarDetalleRuta(RequestBuscarDetalleRutaBody request)
        {
            const string SP = "[dbo].[prc_obtieneReporteRutasDetalle]";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@i_idEjecucionRuta", request.idEjecucion);
            PuntoInspeccionTemporalTO[] listaPtoWS = _dapper.GetAll<PuntoInspeccionTemporalTO>(SP, parameters, commandType: CommandType.StoredProcedure).ToArray();
            Dictionary<long, ValoresEquipoTO> dicEquipos = new Dictionary<long, ValoresEquipoTO>();
            foreach (PuntoInspeccionTemporalTO puntoWS in listaPtoWS)
            {
                ValoresPuntoTO valorPunto = new ValoresPuntoTO();
                valorPunto.titulo = puntoWS.referenciaFisica;
                valorPunto.imagen = puntoWS.imagenPI;
                valorPunto.observaciones = puntoWS.obsPI;
                valorPunto.valor = puntoWS.valorIngresado;
                valorPunto.fechaInspeccion = puntoWS.fechaInspeccion;
                valorPunto.siglaUnidadMedida = puntoWS.siglaUnidadMedida;
                valorPunto.unidadMedida = puntoWS.unidadMedida;
                ValoresEquipoTO valorEquipo;
                 try
                {
                    valorEquipo = (ValoresEquipoTO)dicEquipos[puntoWS.idEjecucionEquipo];
                }
                catch (KeyNotFoundException kne)
                {
                    valorEquipo = new ValoresEquipoTO();
                    valorEquipo.codigoSap = puntoWS.codigoSAP;
                    valorEquipo.foto = puntoWS.imagenEquipo;
                    valorEquipo.nombreEquipo = puntoWS.nombreEquipo;
                    valorEquipo.observacion = puntoWS.obsEquipo;
                    valorEquipo.listaPuntos = new List<ValoresPuntoTO>();
                }
                valorEquipo.listaPuntos.Add(valorPunto);
                dicEquipos[puntoWS.idEjecucionEquipo] = valorEquipo;
            }
            ResponseBuscarDetalleRuta response = new ResponseBuscarDetalleRuta();
            response.listaValoresEquipo = dicEquipos.Values.ToList();
            return response;
        }

        public ResponseBuscarHistoriaEquipo buscarHistoriaEquipo(RequestBuscarHistoriaEquipoBody request)
        {
            const string SP = "[dbo].[prc_obtieneReporteEquipos]";
            ResponseBuscarHistoriaEquipo response = new ResponseBuscarHistoriaEquipo();
            CbxTO[] listaPuntos = obtieneListaCbxPuntoInspeccion(request.idEquipo);
            response.listaPuntosHeader = listaPuntos;
            // Utilizar Dapper para obtener el reporte de equipos
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@i_id_complejo", request.idComplejo);
            parameters.Add("@i_id_central", request.idCentral);
            parameters.Add("@i_id_ruta", request.idRuta);
            parameters.Add("@i_id_equipo", request.idEquipo);
            parameters.Add("@i_fecha_inicio", request.fechaInicio + " 00:00:00");
            parameters.Add("@i_fecha_fin", request.fechaFin + " 23:59:59");
            parameters.Add("@i_criticoMantenedor", request.var_critica);
            ReporteEquipoTO[] listaEquipos = _dapper.GetAll<ReporteEquipoTO>(SP, parameters, CommandType.StoredProcedure).ToArray();
            Dictionary<String, InspeccionEquipoTO> dicInspeccion = new Dictionary<string, InspeccionEquipoTO>();
            InspeccionEquipoTO inspeccionEquipoTO = null;
            for (int i = 0; i < listaEquipos.Length; i++) {
                String fecha = listaEquipos[i].fechaSincronizacion;
                if (!dicInspeccion.ContainsKey(fecha))
                {
                    inspeccionEquipoTO = new InspeccionEquipoTO();
                    inspeccionEquipoTO.fecha = fecha;
                    inspeccionEquipoTO.listaPuntos = cargarPuntosToEquipo(listaPuntos);
                }

                long idPuntoInspeccion = listaEquipos[i].idPuntoInspeccion;
                for (int indPtos = 0; indPtos < inspeccionEquipoTO.listaPuntos.Length; indPtos++)
                {
                    if (idPuntoInspeccion == inspeccionEquipoTO.listaPuntos[indPtos].idPunto)
                    {
                        inspeccionEquipoTO.listaPuntos[indPtos].idPunto = idPuntoInspeccion;
                        inspeccionEquipoTO.listaPuntos[indPtos].observacion = listaEquipos[i].observaciones;
                        inspeccionEquipoTO.listaPuntos[indPtos].valor = listaEquipos[i].valorIngresado;
                    }
                }

                dicInspeccion[fecha] = inspeccionEquipoTO;
            }
            response.listaEquipos = dicInspeccion.Values.ToArray();
            return response;
        }
    }
}
