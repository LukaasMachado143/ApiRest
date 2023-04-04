using AR.Data.Interfaces;
using AR.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioController(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeForID(Guid id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(Funcionario empData)
        {
            return Ok(_repository.Add(empData));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            return Ok(_repository.Remove(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id)
        {
            return Ok(_repository.Update(id));
        }
    }
}
