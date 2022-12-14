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

            try {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado) {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso.";
                }
                else {
                    TempData["MensagemErro"] = $"Ops, não conseguimos apagar o contato.";
                }
                return RedirectToAction("Index");

            }
            catch (Exception erro) {

                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o contato. Detalhe erro: {erro.Message}";
                return RedirectToAction("index");
            }

            
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel Contato) {

            try {
                if (ModelState.IsValid) {

                    _contatoRepositorio.Adicionar(Contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso.";
                    return RedirectToAction("Index");

                }

                return View(Contato);
            }
            catch (Exception erro) {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o contato. Detalhe erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        
        }

        public IActionResult Alterar(ContatoModel contato) {

            try {
                if (ModelState.IsValid) {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);

            }
            catch (Exception erro) {
                TempData["MensagemErro"] = $"Ops, erro ao editar o contato. Detalhe erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

    }
}
