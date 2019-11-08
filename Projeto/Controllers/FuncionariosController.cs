using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFuncionarios.Models;
using ApiFuncionarios.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiFuncionarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FuncionariosController : Controller
    {
        //Instancializando o Repositório.
        private readonly IFuncionarioRepository _funcionarioRepositorio;


        public FuncionariosController(IFuncionarioRepository funcRep)
        {
            _funcionarioRepositorio = funcRep;
        }
        //  funcionarios/list
        [HttpGet]
        public IEnumerable<Funcionario> List()
        {
            return _funcionarioRepositorio.List();
        }

        //  funcionarios/show/id
        [HttpGet("{id}", Name = "GetFuncionario")]
        public IActionResult Show(int id)
        {
            var func = _funcionarioRepositorio.show(id);
            if (func == null)
            {
                return NotFound();
            }
            return new ObjectResult(func);
        }

        //  funcionarios/create
        [HttpPost]
        public IActionResult Create([FromBody] FuncionarioDTO func)
        {
            //FuncionarioDTO
            if (func != null)
            {
                var funcionario_criado = _funcionarioRepositorio.create(func);
                //var resultado = new
                //{
                //    Status = "200",
                //    Mensagem = String.Format("O funcionario foi Criado com sucesso com o ID: {0}", funcionario_criado.Id)
                //};
                //return Json(resultado);
            }
            return NotFound();
        }

        //  funcionarios/destroy
        [HttpGet]
        public string Destroy()
        {
            return "teste felipe";
        }

        //  funcionarios/update
        [HttpGet]
        public string Update()
        {
            return "teste felipe";
        }

    }
}