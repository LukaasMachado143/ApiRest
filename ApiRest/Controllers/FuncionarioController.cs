using AR.Domain.Entidades;
using AR.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly ILogger<FuncionarioController> _logger;

        public FuncionarioController(IFuncionarioService funcionarioService, ILogger<FuncionarioController> logger)
        {
            _funcionarioService = funcionarioService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("Getting employees registred in the database.(Controller)");
                var ListaGerada = await _funcionarioService.GetAll();
                if (ListaGerada == null) {
                    _logger.LogInformation("Non-existent employee list.(Controller)");
                    return NoContent(); }
                return Ok(ListaGerada);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when trying to get all employees registred in the database. Error:{e}. (Controller)");
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to get all employees registred in the database. Error:{e}.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                _logger.LogInformation("Getting employee by id registred in the database.(Controller)");
                var funcionarioEncontrado = await _funcionarioService.GetById(id);
                if (funcionarioEncontrado == null) {
                    _logger.LogInformation("Non-existent employee.(Controller)");
                    return NoContent(); 
                }
                return Ok(funcionarioEncontrado);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when trying to get employee by id registred in the database. Error:{e}. (Controller)");
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to get employee by id registred in the database. Error:{e}.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FuncionarioModel newEmployeeData)
        {
            try
            {
                _logger.LogInformation("Registering a new employee in the database.(Controller)");
                var funcionarioRegistrado = _funcionarioService.Add(newEmployeeData);
                if (funcionarioRegistrado == null) {
                    _logger.LogInformation("Employee not registred.");
                    return this.StatusCode(StatusCodes.Status406NotAcceptable, "There was a problem registering the new employee");
                        }
                return this.StatusCode(StatusCodes.Status201Created, "Employee registred.(Controller).");            }
            catch (Exception e)
            {
                _logger.LogError($"Error when trying to regiter in the database. Error:{e}. (Controller)");
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to regiter in the database. Error:{e}. Erro:{e}");
            }
        }


    }
}
