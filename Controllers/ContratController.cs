using Microsoft.AspNetCore.Mvc;
using ApiContrats.Models;
using ApiContrats.Services;
using ApiContrats.DTOs;

namespace ApiContrats.Controllers
{
    [ApiController]
    [Route("api/contrats")]
    [Produces("application/json")]
    public class ContratController : ControllerBase
    {
        private readonly IContratService _contratService;
        private readonly ILogger<ContratController> _logger;

        public ContratController(IContratService contratService, ILogger<ContratController> logger)
        {
            _contratService = contratService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contrat>>> GetContrats()
        {
            try
            {
                _logger.LogInformation("Obteniendo todos los contratos");
                var contrats = await _contratService.GetAllContratsAsync();

                return Ok(new
                {
                    success = true,
                    data = contrats,
                    message = "Contratos obtenidos exitosamente",
                    count = contrats?.Count
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "Error al obtener contratos: {Message}", ex.Message);
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno del servidor al acceder a la base de datos: " + ex.Message,
                    error = "DATABASE_ERROR"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al obtener contratos: {Message}", ex.Message);
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error inesperado en el servidor",
                    error = "INTERNAL_ERROR"
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Contrat>> CreateContrat([FromBody] ContratCreateDto contratDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        );

                    _logger.LogWarning("Validación fallida al crear contrato: {Errors}", errors);
                    return BadRequest(new
                    {
                        success = false,
                        message = "Datos de entrada inválidos",
                        errors = errors
                    });
                }
                var contrat = new Contrat
                {
                    ContratId = Guid.NewGuid(), 
                    Entity = contratDto.Entity,
                    Validity = contratDto.Validity,
                };

                _logger.LogInformation("Creando nuevo contrato para entidad: {Entity}", contrat.Entity);

                var newContrat = await _contratService.CreateContratAsync(contrat);

                _logger.LogInformation("Contrato creado exitosamente para la entidad: {Entity}", newContrat.Entity);
                return CreatedAtAction(
                    nameof(GetContrats),
                    new
                    {
                        success = true,
                        data = newContrat,
                        message = "Contrato creado exitosamente"
                    });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "Error al crear contrato (InvalidOperationException): {Message}", ex.Message);
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno del servidor al procesar la solicitud: " + ex.Message,
                    error = "BUSINESS_LOGIC_ERROR" 
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al crear contrato: {Message}", ex.Message);
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error inesperado en el servidor",
                    error = "INTERNAL_ERROR"
                });
            }
        }
    }
}