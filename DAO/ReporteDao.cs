using Dapper;
using ReporteWS.cl.colbun.sicap.to.request;
using ReporteWS.cl.colbun.sicap.to.response;
using ris_reporte_rest.DataAccess;
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
            const string SP = "[dbo].[prc_obtieneListaComplejos]";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@i_idEquipo", idEquipo);
            parameters.Add("@i_sinAsignar", "0");
            parameters.Add("@i_idCentral", "0");
            CbxTO[] result = _dapper.GetAll<CbxTO>(SP, parameters, commandType: CommandType.StoredProcedure).ToArray();
            return result;
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

        public PuntoInspeccionTemporalTO[] buscarDetalleRuta(RequestBuscarDetalleRutaBody request)
        {
            const string SP = "[dbo].[prc_obtieneReporteRutasDetalle]";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@i_idEjecucionRuta", request.idEjecucion);
            PuntoInspeccionTemporalTO[] result = _dapper.GetAll<PuntoInspeccionTemporalTO>(SP, parameters, commandType: CommandType.StoredProcedure).ToArray();
            return result;
        }
    }
}
