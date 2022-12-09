using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Models;
using SistemaCadastro.Repositorios;

namespace SistemaCadastro.Controllers {
    public class ContatoController : Controller {

        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio) {

            _contatoRepositorio = contatoRepositorio;
        }


        public IActionResult Index() {
          List<ContatoModel> contatos =  _contatoRepositorio.BuscarTotos();

            return View(contatos);
        }


        public IActionResult Criar() {
            return View();
        }

        public IActionResult Editar() {
            return View();
        }

        public IActionResult ApagarConfirmacao() {
            return View();
        }

        public IActionResult Apagar() {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel Contato) {
            _contatoRepositorio.Adicionar(Contato);
            return RedirectToAction("Index");
        }

    }
}
