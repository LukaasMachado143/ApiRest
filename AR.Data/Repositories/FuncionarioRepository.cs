using AR.Domain.Entidades;
using AR.Domain.Interfaces.Repository;
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


        public async Task<FuncionarioModel[]> GetAll()
        {
            try
            {
                _log.LogInformation("Acessing Database for search all employees.(Repository)");
                IQueryable<FuncionarioModel> ListaFuncionarios = _db.Funcionarios;
                ListaFuncionarios = ListaFuncionarios.AsNoTracking().OrderBy(x => x.FullName);
                return await ListaFuncionarios.ToArrayAsync();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error when trying to get all employees in the database.(Repository)");
                throw;
            }
        }

        public async Task<FuncionarioModel> GetById(Guid id)
        {
            try
            {
                _log.LogInformation("Acessing Database for search the employee by id.(Repository)");
                IQueryable<FuncionarioModel> funcionario = _db.Funcionarios;
                funcionario = funcionario.AsNoTracking();
                return await funcionario.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error when trying to get employee by id in the database.(Repository)");
                throw;
            }
        }

        public async Task AddEmployee(FuncionarioModel funcionario)
        {
            try
            {
                _log.LogInformation("registering employee to the database.(Repository)");
                _db.AddAsync(funcionario);
                _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error when trying registering employee to the database.(Repository)");
                throw;
            }
        }

        public async Task UpdateData(Guid id)
        {
            try
            {
                _log.LogInformation("Changing employee data in the database.(Repository)");
                var funcionarioEncontrado = GetById(id);
                _db.Update(funcionarioEncontrado);
                _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error when trying changing employee data in the database.(Repository)");
                throw;
            }

        }

        public async Task RemoveEmployee(Guid id)
        {
            try
            {
                _log.LogInformation("Removing employee in the database.(Repository)");
                var funcionarioEncontrado = GetById(id);
                _db.Remove(funcionarioEncontrado);
                _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error when trying Removing employee in the database.(Repository)");
                throw;
            }
        }

    }
}
