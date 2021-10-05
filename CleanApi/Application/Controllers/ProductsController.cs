using CleanApi.Domain.Entities.Product;
using CleanApi.Domain.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CleanApi.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _repo.getAll());
        }

        // GET: Products/Details/5
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _repo.getById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(product);

                return CreatedAtAction(nameof(Details), new { Id = product.Id }, product);

            }
            return BadRequest(product);
        }


        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id, [Bind("Description,Price,Name")] Product product)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var prod = await _repo.getById(id);

                    if (prod != null)
                    {
                        int result = await _repo.Update(prod);
                        if (result == 1)
                        {
                            return CreatedAtAction(nameof(Details), new { Id = id }, product);
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExistsAsync(id.Value))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }

        // GET: Products/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _repo.getById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _repo.Remove(product);
            return Ok(product);
        }


        private Task<bool> ProductExistsAsync(int id) => Task.FromResult(_repo.ProductExists(id));
    }
}
