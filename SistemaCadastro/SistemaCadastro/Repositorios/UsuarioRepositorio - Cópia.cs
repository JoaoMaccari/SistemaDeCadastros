using SistemaCadastro.Data;
using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorios {
    public class UsuarioRepositorio : IUsuarioRepositorio {


        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext ) {
            _bancoContext = bancoContext;
        }


        public UsuarioModel ListarPorId(int id) {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel Adicionar(UsuarioModel usuario) {

            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add( usuario );
            _bancoContext.SaveChanges();
            return usuario;
        }

        public List<UsuarioModel> BuscarTotos() {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Atualizar(UsuarioModel usuario) {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuario");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email= usuario.Email;
            usuarioDB.Login= usuarioDB.Login;
            usuarioDB.Perfil= usuarioDB.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id) {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleção do usuario");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
