using ProjetoLivros.DTO;
using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> ListarTodos();

        Livro BuscarPorId(int id);

        void Cadastrar(LivroDTO livro);

        void Atualizar(int id, Livro livro);

        void Deletar(int id);
    }
}
