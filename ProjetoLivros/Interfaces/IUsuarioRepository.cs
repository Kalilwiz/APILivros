using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario usuario);

        void Atualizar(int id, Usuario usuario);

        void Deletar(int id);
    }
}

