using ApiFuncionarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFuncionarios.Repository
{
    public interface IFuncionarioRepository
    {
        IEnumerable<Funcionario> List();
        Funcionario show(int id);
        Funcionario create(FuncionarioDTO funcionario);
        bool destroy(int id);
        Funcionario update(Funcionario funcionario);
    }
}
