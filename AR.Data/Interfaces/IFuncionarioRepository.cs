using AR.Domain;

namespace AR.Data.Interfaces
{
    public interface IFuncionarioRepository
    {
        IQueryable<Funcionario> GetAll();
        IQueryable<Funcionario> GetById(Guid id);
        Task Add(Funcionario funcionario);
        Task Remove(Guid id);
        Task ActData(Guid id);
    }
}
