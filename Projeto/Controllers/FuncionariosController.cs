using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFuncionarios.Models;
using ApiFuncionarios.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiFuncionarios.Controllers
{

    public class BodyID
    {
        public int Id { get; set; }
    }


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
            if (func != null)
            {
                var funcionario_criado = _funcionarioRepositorio.create(func);
                var resultado = new
                {
                    Status = "200",
                    Mensagem = String.Format("O funcionario foi Criado com sucesso com o ID: {0}", funcionario_criado.Id)
                };
                return Json(resultado);
            }
            return NotFound();
        }

        //  funcionarios/destroy
        [HttpPost]
        public IActionResult Destroy([FromBody] BodyID func)
        {
            var func_destroy = _funcionarioRepositorio.destroy(func.Id);

            var retorno = new
            {
                Status = "200",
                Mensagem = "O funcionario foi Excluido."
            };

            if (func_destroy)
                return Json(retorno);


            retorno.Status = "400";
            retorno.Mensagem = "O funcionario não foi excluido.";

            return Json(retorno);
        }

        //  funcionarios/update
        [HttpPost]
        public IActionResult Update([FromBody] FuncionarioDTO func)
        {
            var resultado = _funcionarioRepositorio.update(func);

            var retorno = new
            {
                Status = "200",
                Mensagem = "O funcionario foi atualizado."
            };

            if (func_destroy)
                return Json(retorno);


            retorno.Status = "400";
            retorno.Mensagem = "O funcionario não foi atualizado.";

            return Json(retorno);
        }

    }
}