using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorios {
    public interface IUsuarioRepositorio {

        UsuarioModel ListarPorId(int id);   

        List<UsuarioModel> BuscarTotos();


        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
    }
}
