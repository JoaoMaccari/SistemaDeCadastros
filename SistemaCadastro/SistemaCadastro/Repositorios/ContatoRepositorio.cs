using SistemaCadastro.Data;
using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorios {
    public class ContatoRepositorio : IContatoRepositorio {


        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext ) {
            _bancoContext = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato) {
            
            _bancoContext.Contatos.Add( contato );
            _bancoContext.SaveChanges();
            return contato;
        }

        public List<ContatoModel> BuscarTotos() {
            return _bancoContext.Contatos.ToList();
        }
    }
}
