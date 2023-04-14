using AR.Domain.Entidades;

namespace AR.Domain.Interfaces.Repository
{
    public interface IFuncionarioRepository
    {
        Task<List<Funcionario>> GetAll();
        Task<Funcionario> GetById(Guid id);
        Task Add(Funcionario funcionario);
        Task Remove(Guid id);
        Task UpdateData(Guid id);
    }
}
