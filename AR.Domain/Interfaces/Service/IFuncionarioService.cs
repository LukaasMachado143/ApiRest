using AR.Domain.Entidades;

namespace AR.Domain.Interfaces.Service
{
    public interface IFuncionarioService
    {
        Task<FuncionarioModel[]> GetAll();
        Task<FuncionarioModel> GetById(int id);
        Task Add(FuncionarioModel funcionario);
        Task Remove(int id, FuncionarioModel funcionario);
        Task Update(int id, FuncionarioModel funcionario);
    }
}
