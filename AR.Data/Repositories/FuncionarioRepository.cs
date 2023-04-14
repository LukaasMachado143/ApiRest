using AR.Domain.Entidades;
using AR.Domain.Interfaces.Repository;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AR.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DataContext _db;
        private readonly ILogger<FuncionarioRepository> _log;

        public FuncionarioRepository(DataContext db, ILogger<FuncionarioRepository> _log)
        {
            _db = db;
            _log = _log;
        }


        public Task<List<Funcionario>> GetAll()
        {
            _log.LogInformation("Acessing Database for search all employees.");
            try
            {
                throw; 
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error when trying to get all employees in the database");
                throw;
            }
        }

        public Task<Funcionario> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Funcionario funcionario)
        {
            _log.LogInformation("registering employee to the database.");
            try
            {
                await _db.AddAsync(funcionario);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error when trying registering employee to the database.");
                throw;
            }
        }

        public Task UpdateData(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
