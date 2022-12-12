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

        public IActionResult Editar(int id) {
            ContatoModel contato =  _contatoRepositorio.ListarPorId(id);

            
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id) {

            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id) {

            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel Contato) {
            _contatoRepositorio.Adicionar(Contato);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(ContatoModel contato) {
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }

    }
}
