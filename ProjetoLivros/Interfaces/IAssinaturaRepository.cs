using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface IAssinaturaRepository
    {
        List<Assinatura> ListarTodos();

        Assinatura BuscarPorId(int id);

        void Cadastrar(Assinatura assinatura);

        void Atualizar(int id, Assinatura assinatura);

        void Deletar(int id);
    }
}
