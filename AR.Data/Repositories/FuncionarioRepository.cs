using AR.Data.Interfaces;
using AR.Domain;
using Microsoft.EntityFrameworkCore;

namespace AR.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DataContext _db;

        public FuncionarioRepository(DataContext db)
        {
            _db = db;
        }

        public IQueryable<Funcionario> GetAll()
        {
            return _db.Funcionarios;
        }

        public async Task<IQueryable<Funcionario>> GetById(Guid id)
        {
            IQueryable<Funcionario> query = _db.Funcionarios;
            query = query.AsNoTracking()
                         .OrderBy(func => func.Id);
            await query.FirstOrDefaultAsync(a => a.Id == id);
            return query;
        }

        public async Task Add(Funcionario funcionario)
        {
            await _db.AddAsync(funcionario);
            await _db.SaveChangesAsync();
        }

        public async Task<Funcionario> Update(Guid id)
        {
            var funcionarioEncontrado = GetById(id);
            _db.Update(funcionarioEncontrado);
            await _db.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var funcionarioEncontrado = GetById(id);
            _db.Remove(funcionarioEncontrado);
            await _db.SaveChangesAsync();
        }

    }
}
