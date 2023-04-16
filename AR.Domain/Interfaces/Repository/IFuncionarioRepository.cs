using AR.Domain.Entidades;

namespace AR.Domain.Interfaces.Repository
{
    public interface IFuncionarioRepository
    {
        Task<FuncionarioModel[]> GetAll();
        Task<FuncionarioModel> GetById(int id);
        Task AddEmployee(FuncionarioModel funcionario);
        Task RemoveEmployee(FuncionarioModel funcionario);
        Task UpdateData(FuncionarioModel funcionario);
    }
}
