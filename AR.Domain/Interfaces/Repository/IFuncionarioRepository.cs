using AR.Domain.Entidades;

namespace AR.Domain.Interfaces.Repository
{
    public interface IFuncionarioRepository
    {
        Task<FuncionarioModel[]> GetAll();
        Task<FuncionarioModel> GetById(Guid id);
        Task AddEmployee(FuncionarioModel funcionario);
        Task RemoveEmployee(Guid id);
        Task UpdateData(Guid id);
    }
}
