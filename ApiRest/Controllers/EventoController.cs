using AR.Domain.Entidades;
using AR.Domain.Interfaces.Service;
using AR.Domain.Models;
using AR.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private readonly ILogger<EventoController> _logger;

        public EventoController(IEventoService eventoService, ILogger<EventoController> logger)
        {
            _eventoService = eventoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaEventos = await _eventoService.GetAllEvents();
                if (listaEventos == null)
                {
                    _logger.LogInformation("Non-existent event list.(Controller)");
                    return NoContent();
                }
                return Ok(listaEventos);
            }
            catch (Exception e)
            {

                _logger.LogError($"Error when trying to get all events registred in the database. Error:{e}. (Controller)");
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to get all events registred in the database. Error:{e}.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogInformation("Getting event by id registred in the database.(Controller)");
                var eventoEncontrado = await _eventoService.GetEventById(id);
                if (eventoEncontrado == null)
                {
                    _logger.LogInformation("Non-existent event.(Controller)");
                    return NoContent();
                }
                return Ok(eventoEncontrado);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when trying to get event by id registred in the database. Error:{e}. (Controller)");
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to get event by id registred in the database. Error:{e}.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoModel newEvent)
        {
            try
            {
                if (newEvent != null) { 
                    _logger.LogInformation("Registering a new employee in the database.(Controller)");
                    await _eventoService.AddEvent(newEvent);
                    return this.StatusCode(StatusCodes.Status201Created, "Employee registred.(Controller).");
                }
                else
                {
                    _logger.LogInformation("The parameter gived is nullm please verify your data given.");
                    return this.StatusCode(StatusCodes.Status406NotAcceptable, "The parameter gived is nullm please verify your data given.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when trying to regiter in the database. Error:{e}. (Controller)");
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to regiter in the database. Error:{e}. Erro:{e}");
            }
        }

    }
}
