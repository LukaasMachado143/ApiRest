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
                return ListaFuncionarios;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<FuncionarioModel> GetById(int id)
        {
            try
            {
                if (id != null)
                {
                    var funcionarioEncontrado = await _funcionarioRepository.GetById(id);
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

        public async Task Update(int id, FuncionarioModel dadosAtualizado)
        {

            try
            {
                var funcionarioEncontrado = await _funcionarioRepository.GetById(id);
                if (funcionarioEncontrado.Id == id && funcionarioEncontrado != null)
                {
                    await _funcionarioRepository.UpdateData(dadosAtualizado);
                }
                else
                {
                    throw new Exception("Funcionário inexistente, não será possível editá-lo");
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task Remove(int id, FuncionarioModel funcionarioDeletado)
        {
            try
            {
                var funcionarioEncontrado = await _funcionarioRepository.GetById(id);
                if (funcionarioEncontrado.Id == id && funcionarioEncontrado != null)
                {
                    await _funcionarioRepository.RemoveEmployee(funcionarioDeletado);
                }
                else
                {
                    throw new Exception("Funcionário inexistente, não será possível Removê-lo");
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
