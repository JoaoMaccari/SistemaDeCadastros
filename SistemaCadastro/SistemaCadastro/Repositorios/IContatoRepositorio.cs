using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorios {
    public interface IContatoRepositorio {

        ContatoModel ListarPorId(int id);   

        List<ContatoModel> BuscarTotos();


        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
