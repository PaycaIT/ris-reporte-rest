using InterceptorSicap.cl.colbun.session.to;
using ris_reporte_rest.DAO;
using ris_reporte_rest.DataAccess;
using ris_reporte_rest.Exceptions;
using ris_reporte_rest.Models.Requests;
using ris_reporte_rest.Models.Responses;
using ris_reporte_rest.Models.TO;

namespace ris_reporte_rest.Helper
{
    public class ReporteHelper
    {
        private ReporteDao dao;

        public ReporteHelper(IDapper dapper, ILoggerManager logger)
        {
            this.dao = new ReporteDao(dapper, logger);
        }

        public void validarSession(string codigoUsuario, string token)
        {
            long sessionValida = 0;
            try
            {
                sessionValida = dao.validarSession(codigoUsuario, token);
            }
            catch (Exception e)
            {
                GestionIspeccionException connectionFault = new GestionIspeccionException();
                connectionFault.code = TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXCEPCION;
                connectionFault.userMessage = "Error al validar sesión";
                connectionFault.action = "Excepción al validar sesión: " + e.Message;
                throw connectionFault;
            }

            if (sessionValida == 0)
            {
                GestionIspeccionException connectionFault = new GestionIspeccionException();
                connectionFault.code = TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXPIRADA;
                connectionFault.userMessage = "Sesión no valida";
                connectionFault.action = "Error al validar sesión";
                throw connectionFault;
            }
        }

        public AlertaTO[] buscarAlertas(long idComplejo, long idCentral, long idUsuario, long idEquipo, string fechaInicio, string fechaFin)
        {
            return dao.buscarAlertas(idComplejo, idCentral, idUsuario, idEquipo, fechaInicio, fechaFin);
        }

        public BitacoraTO[] buscarBitacora(long idComplejo, long idCentral, String fechaInicio, String fechaFin)
        {
            return dao.buscarBitacora(idComplejo, idCentral, fechaInicio, fechaFin);
        }

        public ResponseBuscarDetalleRuta buscarDetalleRuta(long idEjecucion)
        {
            return dao.buscarDetalleRuta(idEjecucion);
        }

        public ResponseBuscarHistoriaEquipo buscarHistoriaEquipo(long idComplejo, long idCentral, long idRuta, long idEquipo, string fechaInicio, string fechaFin, bool var_critica)
        {
            return dao.buscarHistoriaEquipo(idComplejo, idCentral, idRuta, idEquipo, fechaInicio, fechaFin, var_critica);
        }

        public RutaTO[] buscarRutas(int idComplejo, int idCentral, bool mant_ope, string estado, string fechaInicio, string fechaFin)
        {
            return dao.buscarRutas(idComplejo, idCentral, mant_ope, estado, fechaInicio, fechaFin);
        }
    }
}
