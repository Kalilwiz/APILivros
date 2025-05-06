using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTodos();

        TipoUsuario BuscarPorId(int id);

        void Cadastrar(TipoUsuario tipoUsuario);

        void Atualizar(int id, TipoUsuario tipoUsuario);

        void Deletar(int id);
    }
}
