using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.DTO;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoria)
        {
            _categoriaRepository = categoria;
        }

        [HttpGet]

        public IActionResult ListarProdutos()
        {
            return Ok(_categoriaRepository.ListarTodos());
        }

        [HttpPost]

        public IActionResult CadastrarCategoria(CategoriaDTO categoria)
        {
            _categoriaRepository.Cadastrar(categoria);

            return Created();
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            Categoria categoria = _categoriaRepository.BuscarPorId(id);

            if (categoria == null)
            {
                throw new Exception();
            }

            return Ok(categoria);
        }

        [HttpPut("{id}")]

        public IActionResult Alterar(int id, CategoriaDTO categoria)
        {
            try
            {
                _categoriaRepository.Atualizar(id, categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult deletar(int id)
        {

            try
            {
                _categoriaRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }
    }
}
