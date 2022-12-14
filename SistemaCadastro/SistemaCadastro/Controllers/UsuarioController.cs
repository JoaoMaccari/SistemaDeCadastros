using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Models;
using SistemaCadastro.Repositorios;

namespace SistemaCadastro.Controllers {
    public class UsuarioController : Controller {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) {

            _usuarioRepositorio = usuarioRepositorio;
        }


        public IActionResult Index() {

            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTotos();

            return View();
        }


        public IActionResult Criar() {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario) {

            try {
                if (ModelState.IsValid) {

                    usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso.";
                    return RedirectToAction("Index");

                }

                return View(usuario);
            }
            catch (Exception erro) {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário. Detalhe erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
