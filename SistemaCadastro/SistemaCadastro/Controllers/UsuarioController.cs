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

            return View(usuarios);
        }


        public IActionResult Criar() {
            return View();
        }


        public IActionResult Editar(int id) {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);


            return View(usuario);
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


        public IActionResult ApagarConfirmacao(int id) {

            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id) {

            try {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado) {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso.";
                }
                else {
                    TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário.";
                }
                return RedirectToAction("Index");

            }
            catch (Exception erro) {

                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o usuário. Detalhe erro: {erro.Message}";
                return RedirectToAction("index");
            }
        }

        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel) {

            try {

                UsuarioModel usuario = null;

                if (ModelState.IsValid) {

                    usuario = new UsuarioModel() {

                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };
                   
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View(usuario);

            }
            catch (Exception erro) {
                TempData["MensagemErro"] = $"Ops, erro ao editar o contato. Detalhe erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }




    }
}
