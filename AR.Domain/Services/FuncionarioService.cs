using AR.Domain.Entidades;
using AR.Domain.Interfaces.Repository;
using AR.Domain.Interfaces.Service;


namespace AR.Domain.Services
{
    public class FuncionarioService : IFuncionarioService
    {

        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funciodaRepository)
        {
            _funcionarioRepository = funciodaRepository;
        }

        public Task<FuncionarioModel[]> GetAll()
        {
            try
            {
                var ListaFuncionarios = _funcionarioRepository.GetAll();
                if (ListaFuncionarios == null) { return null; }
                return ListaFuncionarios;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<FuncionarioModel> GetById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    var funcionarioEncontrado = await _funcionarioRepository.GetById(id);
                    if (funcionarioEncontrado == null) { return null; }
                    return funcionarioEncontrado;
                }
                else
                {
                    throw new Exception("Funcionário Inexistente, favor adicioná-lo antes de procurá-lo");
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task Add(FuncionarioModel funcionario)
        {
            try
            {
                if (funcionario != null && await _funcionarioRepository.GetById(funcionario.Id) == null)
                {
                    await _funcionarioRepository.AddEmployee(funcionario);
                }
                else
                {
                    throw new Exception("Funcionário com ID já existente, não será possível adicioná-lo");
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task Update(Guid id)
        {

            try
            {
                if (await _funcionarioRepository.GetById(id) == null)
                {
                    await _funcionarioRepository.UpdateData(id);
                }
                else
                {
                    throw new Exception("Funcionário com ID inexistente, não será possível editá-lo");
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task Remove(Guid id)
        {
            try
            {
                if (await _funcionarioRepository.GetById(id) == null)
                {
                    await _funcionarioRepository.RemoveEmployee(id);
                }
                else
                {
                    throw new Exception("Funcionário com ID inexistente, não será possível Removê-lo");
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
