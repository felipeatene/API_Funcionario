using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFuncionarios.Models;

namespace ApiFuncionarios.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly FuncionarioDbContext _funcionarios;

        public FuncionarioRepository(FuncionarioDbContext func)
        {
            _funcionarios = func;
        }

        public IEnumerable<Funcionario> List()
        {
            return _funcionarios.Funcionarios.ToList();
        }
        public Funcionario show(int id)
        {
            var func = _funcionarios.Funcionarios.Where(i => i.Id == id).FirstOrDefault();

            return func;
        }

        public Funcionario create(FuncionarioDTO funcionario)
        {
            try
            {

                _funcionarios.Funcionarios.Add(new Funcionario
                {
                    Nome = funcionario.Nome,
                    Email = funcionario.Email,
                    Endereco = funcionario.Endereco,
                    Telefone = funcionario.Telefone,
                    Salario = Convert.ToDouble(funcionario.Salario),
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                });
                _funcionarios.SaveChanges();

                return _funcionarios.Funcionarios.Find(funcionario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //True --> Excluido
        //False --> Não Excluido
        public bool destroy(int id)
        {
            var func = _funcionarios.Funcionarios.First(i => i.Id == id);
            if (func != null)
            {
                _funcionarios.Funcionarios.Remove(func);
                _funcionarios.SaveChanges();
                return true;
            }
            return false;
        }
        public Funcionario update(Funcionario funcionario)
        {
            _funcionarios.Funcionarios.Update(funcionario);
            _funcionarios.SaveChanges();

            return _funcionarios.Funcionarios.Find(funcionario);
        }
    }
}
