using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReporteWS.cl.colbun.sicap.to.request;
using ReporteWS.cl.colbun.sicap.to.response;
using ris_reporte_rest.DAO;
using ris_reporte_rest.DataAccess;

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
            this.dao = new ReporteDao(dapper);
        }

        [Route("desktop/buscarBitacora")]
        [HttpGet] // Cambia a [HttpGet]
        [EnableCors("MyPolicy")]
        public ResponseBuscarBitacora buscarBitacora([FromQuery] int idComplejo, [FromQuery] int idCentral, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            _logger.LogInformation("buscarBitacora inici�...");
            ResponseBuscarBitacora response = new ResponseBuscarBitacora();
            try
            {
                RequestBuscarBitacoraBody request = new RequestBuscarBitacoraBody { idComplejo = idComplejo, idCentral = idCentral, fechaInicio = fechaInicio, fechaFin = fechaFin };
                response.listaBitacora = dao.buscarBitacora(request);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en buscarBitacora " + ex.Message, ex);
            }
            return response;
        }

        [Route("desktop/buscarRutas")]
        [HttpGet] // Cambia a [HttpGet]
        [EnableCors("MyPolicy")]
        public ResponseBuscarRutas buscarRutas([FromQuery] int idComplejo, [FromQuery] int idCentral, [FromQuery] bool mant_ope, [FromQuery] string estado, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            _logger.LogInformation("buscarRutas inici�...");
            ResponseBuscarRutas response = new ResponseBuscarRutas();
            try
            {
                RequestBuscarRutasBody request = new RequestBuscarRutasBody { idComplejo = idComplejo, idCentral = idCentral, mant_ope = mant_ope, estado = estado, fechaInicio = fechaInicio, fechaFin = fechaFin };
                response.listaRutas = dao.buscarRutas(request);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en buscarRutas " + ex.Message, ex);
            }
            return response;
        }

        [Route("desktop/buscarAlertas")]
        [HttpGet] // Cambia a [HttpGet]
        [EnableCors("MyPolicy")]
        public ResponseBuscarAlertas buscarAlertas([FromQuery] int idComplejo, [FromQuery] int idCentral, [FromQuery] long idUsuario, [FromQuery] long idEquipo, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            _logger.LogInformation("buscarAlertas inici�...");
            ResponseBuscarAlertas response = new ResponseBuscarAlertas();
            try
            {
                RequestBuscarAlertasBody request = new RequestBuscarAlertasBody { idComplejo = idComplejo, idCentral = idCentral, idUsuario = idUsuario, idEquipo = idEquipo, fechaInicio = fechaInicio, fechaFin = fechaFin };
                response.listaAlertas = dao.buscarAlertas(request);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en buscarAlertas " + ex.Message, ex);
            }
            return response;
        }

        //faltan 2 metodos que migrar del servicio reporte
    }
}