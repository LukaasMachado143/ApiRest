using AR.Domain.Entidades;

namespace AR.Domain.Interfaces.Service
{
    public interface IFuncionarioService
    {
        Task<FuncionarioModel[]> GetAll();
        Task<FuncionarioModel> GetById(Guid id);
        Task Add(FuncionarioModel funcionario);
        Task Remove(Guid id);
        Task Update(Guid id);
    }
}
