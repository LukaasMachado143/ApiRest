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
            return Ok("Teste da API");
        }
        
    }
}
