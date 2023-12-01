using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ris_reporte_rest.DAO;
using ris_reporte_rest.DataAccess;
using ris_reporte_rest.Exceptions;
using ris_reporte_rest.Helper;
using ris_reporte_rest.Models.Responses;
using ris_reporte_rest.Models.TO;
using System.Configuration;
using System.Net;

namespace ris_reporte_rest.Controllers
{
    [Produces("application/json")]
    [Route("api/ris/reporte")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ReporteController : ControllerBase
    {

        private readonly IDapper _dapper;
        private readonly IConfiguration _config;
        private readonly ILoggerManager _logger;
        private ReporteHelper helper;
        public ReporteController(IConfiguration config, IDapper dapper, ILoggerManager logger)
        {
            this._config = config;
            this._dapper = dapper;
            this._logger = logger;
            this.helper = new ReporteHelper(dapper, logger);
        }
        
        [Route("obtenerBitacora")]
        [HttpGet] // Cambia a [HttpGet]
        [EnableCors("MyPolicy")]
        public IActionResult obtenerBitacora([FromHeader] String codigoUsuario, [FromHeader] String token, [FromQuery] long idComplejo, [FromQuery] long idCentral, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            ResponseBuscarBitacora response = new ResponseBuscarBitacora();
            try
            {
                helper.validarSession(codigoUsuario, token);
                response.listaBitacora = helper.buscarBitacora(idComplejo, idCentral, fechaInicio, fechaFin);
            }
            catch (GestionIspeccionException ex)
            {
                this._logger.LogError("Error en obtenerBitacora: " + ex.action, ex);
                if (ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXCEPCION || ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXPIRADA)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ErrorTO(ex.code, ex.userMessage));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(ex.code, ex.userMessage));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error en obtenerBitacora: " + ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(TiposErrores.CODE_ERROR_NO_CONTROLADO, ex.Message));
            }

            return StatusCode((int)HttpStatusCode.OK, response);
        }

        [Route("obtenerRutas")]
        [HttpGet] // Cambia a [HttpGet]
        [EnableCors("MyPolicy")]
        public IActionResult obtenerRutas([FromHeader] String codigoUsuario, [FromHeader] String token, [FromQuery] int idComplejo, [FromQuery] int idCentral, [FromQuery] bool mant_ope, [FromQuery] string? estado, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            ResponseBuscarRutas response = new ResponseBuscarRutas();
            try
            {
                helper.validarSession(codigoUsuario, token);
                response.listaRutas = helper.buscarRutas(idComplejo, idCentral, mant_ope, estado, fechaInicio, fechaFin);
            }
            catch (GestionIspeccionException ex)
            {
                this._logger.LogError("Error en obtenerRutas: " + ex.action, ex);
                if (ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXCEPCION || ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXPIRADA)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ErrorTO(ex.code, ex.userMessage));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(ex.code, ex.userMessage));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error en obtenerRutas: " + ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(TiposErrores.CODE_ERROR_NO_CONTROLADO, ex.Message));
            }

            return StatusCode((int)HttpStatusCode.OK, response);
        }

        [Route("obtenerAlertas")]
        [HttpGet] // Cambia a [HttpGet]
        [EnableCors("MyPolicy")]
        public IActionResult obtenerAlertas([FromHeader] String codigoUsuario, [FromHeader] String token, [FromQuery] long idComplejo, [FromQuery] long idCentral, [FromQuery] long idUsuario, [FromQuery] long idEquipo, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            ResponseBuscarAlertas response = new ResponseBuscarAlertas();
            try
            {
                helper.validarSession(codigoUsuario, token);
                response.listaAlertas = helper.buscarAlertas(idComplejo, idCentral, idUsuario, idEquipo, fechaInicio, fechaFin);
            }
            catch (GestionIspeccionException ex)
            {
                this._logger.LogError("Error en obtenerAlertas: " + ex.action, ex);
                if (ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXCEPCION || ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXPIRADA)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ErrorTO(ex.code, ex.userMessage));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(ex.code, ex.userMessage));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error en obtenerAlertas: " + ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(TiposErrores.CODE_ERROR_NO_CONTROLADO, ex.Message));
            }

            return StatusCode((int)HttpStatusCode.OK, response);
        }

        [Route("obtenerDetalleRuta")]
        [HttpGet] // Cambia a [HttpGet]
        [EnableCors("MyPolicy")]
        public IActionResult obtenerDetalleRuta([FromHeader] String codigoUsuario, [FromHeader] String token, [FromQuery] long idEjecucion)
        {
            ResponseBuscarDetalleRuta response = new ResponseBuscarDetalleRuta();
            try
            {
                helper.validarSession(codigoUsuario, token);
                response = helper.buscarDetalleRuta(idEjecucion);
            }
            catch (GestionIspeccionException ex)
            {
                this._logger.LogError("Error en obtenerDetalleRuta: " + ex.action, ex);
                if (ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXCEPCION || ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXPIRADA)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ErrorTO(ex.code, ex.userMessage));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(ex.code, ex.userMessage));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error en obtenerDetalleRuta: " + ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(TiposErrores.CODE_ERROR_NO_CONTROLADO, ex.Message));
            }

            return StatusCode((int)HttpStatusCode.OK, response);
        }

        //faltan 2 metodos que migrar del servicio reporte
        [Route("obtenerHistoriaEquipo")]
        [HttpGet] // Cambia a [HttpGet]
        [EnableCors("MyPolicy")]
        public IActionResult obtenerHistoriaEquipo([FromHeader] String codigoUsuario, [FromHeader] String token, [FromQuery] long idComplejo, [FromQuery] long idCentral, [FromQuery] long idRuta, [FromQuery] long idEquipo, [FromQuery] string fechaInicio, [FromQuery] string fechaFin, [FromQuery] bool var_critica)
        {
            ResponseBuscarHistoriaEquipo response = new ResponseBuscarHistoriaEquipo();
            try
            {
                helper.validarSession(codigoUsuario, token);
                response = helper.buscarHistoriaEquipo(idComplejo, idCentral, idRuta, idEquipo, fechaInicio, fechaFin, var_critica);
            }
            catch (GestionIspeccionException ex)
            {
                this._logger.LogError("Error en obtenerHistoriaEquipo: " + ex.action, ex);
                if (ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXCEPCION || ex.code == TiposErrores.CODE_ERROR_SESION_NO_VALIDA_EXPIRADA)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ErrorTO(ex.code, ex.userMessage));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(ex.code, ex.userMessage));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error en obtenerHistoriaEquipo: " + ex.Message, ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorTO(TiposErrores.CODE_ERROR_NO_CONTROLADO, ex.Message));
            }

            return StatusCode((int)HttpStatusCode.OK, response);
        }
    }
}