using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ris_reporte_rest.DAO;
using ris_reporte_rest.DataAccess;
using ris_reporte_rest.Exceptions;
using ris_reporte_rest.Models.Requests;
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
        private ReporteDao dao;
        public ReporteController(IConfiguration config, IDapper dapper, ILoggerManager logger)
        {
            this._config = config;
            this._dapper = dapper;
            this._logger = logger;
            Configuration = config;
            this.dao = new ReporteDao(dapper, logger);
        }
        public IConfiguration Configuration { get; }
        [Route("obtenerBitacora")]
        [HttpGet] // Cambia a [HttpGet]
        [EnableCors("MyPolicy")]
        public IActionResult obtenerBitacora([FromQuery] int idComplejo, [FromQuery] int idCentral, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            _logger.LogInformation("obtenerBitacora inició...");
            ResponseBuscarBitacora response = new ResponseBuscarBitacora();
            try
            {
                RequestBuscarBitacoraBody request = new RequestBuscarBitacoraBody { idComplejo = idComplejo, idCentral = idCentral, fechaInicio = fechaInicio, fechaFin = fechaFin };
                response.listaBitacora = dao.buscarBitacora(request);
            }
            catch (GestionReporteException ex)
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
        public IActionResult obtenerRutas([FromQuery] int idComplejo, [FromQuery] int idCentral, [FromQuery] bool mant_ope, [FromQuery] string estado, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            _logger.LogInformation("obtenerRutas inició...");
            ResponseBuscarRutas response = new ResponseBuscarRutas();
            try
            {
                RequestBuscarRutasBody request = new RequestBuscarRutasBody { idComplejo = idComplejo, idCentral = idCentral, mant_ope = mant_ope, estado = estado, fechaInicio = fechaInicio, fechaFin = fechaFin };
                response.listaRutas = dao.buscarRutas(request);
            }
            catch (GestionReporteException ex)
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
        public IActionResult obtenerAlertas([FromQuery] int idComplejo, [FromQuery] int idCentral, [FromQuery] long idUsuario, [FromQuery] long idEquipo, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            _logger.LogInformation("obtenerAlertas inició...");
            ResponseBuscarAlertas response = new ResponseBuscarAlertas();
            try
            {
                RequestBuscarAlertasBody request = new RequestBuscarAlertasBody { idComplejo = idComplejo, idCentral = idCentral, idUsuario = idUsuario, idEquipo = idEquipo, fechaInicio = fechaInicio, fechaFin = fechaFin };
                response.listaAlertas = dao.buscarAlertas(request);
            }
            catch (GestionReporteException ex)
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
        public IActionResult obtenerDetalleRuta([FromQuery] int idEjecucion)
        {
            _logger.LogInformation("obtenerDetalleRuta inició...");
            ResponseBuscarDetalleRuta response = new ResponseBuscarDetalleRuta();
            try
            {
                RequestBuscarDetalleRutaBody request = new RequestBuscarDetalleRutaBody { idEjecucion = idEjecucion };
                response = dao.buscarDetalleRuta(request);
            }
            catch (GestionReporteException ex)
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
        public IActionResult obtenerHistoriaEquipo([FromQuery] long idComplejo, [FromQuery] long idCentral, [FromQuery] long idRuta, [FromQuery] long idEquipo, [FromQuery] string fechaInicio, [FromQuery] string fechaFin, [FromQuery] bool var_critica)
        {
            _logger.LogInformation("obtenerHistoriaEquipo inició...");
            ResponseBuscarHistoriaEquipo response = new ResponseBuscarHistoriaEquipo();
            try
            {
                RequestBuscarHistoriaEquipoBody request = new RequestBuscarHistoriaEquipoBody { idComplejo = idComplejo, idCentral = idCentral, idRuta = idRuta, idEquipo = idEquipo, fechaInicio = fechaInicio, fechaFin = fechaFin, var_critica = var_critica };
                response = dao.buscarHistoriaEquipo(request);
            }
            catch (GestionReporteException ex)
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