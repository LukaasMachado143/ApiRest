using AR.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR.Domain.Interfaces.Service
{
    public interface IFuncionarioService
    {
        Task<List<Funcionario>> GetAll();
        Task<Funcionario> GetById(Guid id);
        Task Add(Funcionario funcionario);
        Task Remove(Guid id);
        Task UpdateData(Guid id);
    }
}
}
