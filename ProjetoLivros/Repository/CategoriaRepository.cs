using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Context;
using ProjetoLivros.DTO;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    public class CategoriaRepository : ICategoriaRepository

    {
        private readonly LivrosContext _context;

        public CategoriaRepository(LivrosContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, CategoriaDTO categoria)
        {
            Categoria produtoencontrado = _context.Categorias.Find(id);

            if (produtoencontrado == null)
            {
                throw new Exception();
            }

            produtoencontrado.NomeCategoria = categoria.NomeCategoria;

            _context.SaveChanges();
        }

        public Categoria BuscarPorId(int id)
        {
            return _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        }

        public void Cadastrar(CategoriaDTO dto)
        {
            Categoria categoria = new Categoria

            {
                NomeCategoria = dto.NomeCategoria,
            };

            _context.Add(categoria);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Categoria categoriaEncontrada = _context.Categorias.Find(id);

            // verifica se o valor encontrado nao e null e se for cria um erro
            if (categoriaEncontrada == null)
            {
                throw new Exception();
            }

            // manda para o contexto e salva
            _context.Categorias.Remove(categoriaEncontrada);
            _context.SaveChanges();
        }

        public List<Categoria> ListarTodos()
        {
            return _context.Categorias.ToList();

        }
    }
}