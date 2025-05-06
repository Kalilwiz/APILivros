using ProjetoLivros.Context;
using ProjetoLivros.DTO;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    public class LivroRepository : ILivroRepository
    {

        private readonly LivrosContext _context;

        public LivroRepository(LivrosContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Livro livro)
        {
            Livro livroEncontrado = _context.Livros.Find(id);

            if (livroEncontrado == null)
            {
                throw new Exception();
            }

            livroEncontrado.Titulo = livro.Titulo;
            livroEncontrado.Autor = livro.Autor;
            livroEncontrado.Descricao = livro.Descricao;
            livroEncontrado.DataPublicacao = livro.DataPublicacao;

            _context.SaveChanges();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.FirstOrDefault(l => l.LivroId == id);
        }

        public void Cadastrar(LivroDTO dto)
        {
            Livro livro = new Livro
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                Descricao = dto.Descricao,
                DataPublicacao = dto.DataPublicacao,
            };

            _context.Add(livro);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro livroEcontrado = _context.Livros.Find(id);

            if (livroEcontrado == null)
            {
                throw new Exception();
            }

            _context.Livros.Remove(livroEcontrado);
            _context.SaveChanges();
        }

        public List<Livro> ListarTodos()
        {
            return _context.Livros.ToList();
        }
    }
}
