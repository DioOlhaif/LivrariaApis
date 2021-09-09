using LivrariaApis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class livrariaController: ControllerBase
    {

        private readonly ToDoContext _context;

    public livrariaController(ToDoContext context)
        {
            _context = context;
            context.todoProducts.Add(new Produto { ID = "1", Nome = "Livro 1", Preco = 10.50, Quant = 1, Categoria = "Terror", Img = "1" });
            context.todoProducts.Add(new Produto { ID = "2", Nome = "Livro 2", Preco = 10.50, Quant = 1, Categoria = "Terror", Img = "2" });
            context.todoProducts.Add(new Produto { ID = "3", Nome = "Livro 3", Preco = 10.50, Quant = 1, Categoria = "Terror", Img = "3" });
            context.todoProducts.Add(new Produto { ID = "4", Nome = "Livro 4", Preco = 10.50, Quant = 1, Categoria = "Terror", Img = "4" });

            context.SaveChanges();
        
        }
            
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> Getprodutos()
        {
            return await _context.todoProducts.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Produto>> GetItem(int id)
        {
            var item = await _context.todoProducts.FindAsync(id.ToString());
            if (item == null)
            {

                return NotFound();
            }
            return item;
        
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {

            if (ModelState.IsValid) {

                _context.todoProducts.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        
                    }
            return produto;
        }
    
    
    }
}
