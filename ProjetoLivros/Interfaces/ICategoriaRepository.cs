using ProjetoLivros.DTO;
using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria> ListarTodos();

        Categoria BuscarPorId(int id);

        void Cadastrar(CategoriaDTO categoria);

        void Atualizar(int id, CategoriaDTO categoria);

        void Deletar(int id);
    }
}
