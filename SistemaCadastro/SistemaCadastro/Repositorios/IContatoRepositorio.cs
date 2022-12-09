using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorios {
    public interface IContatoRepositorio {

        List<ContatoModel> BuscarTotos();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
