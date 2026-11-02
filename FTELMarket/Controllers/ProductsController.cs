using FTELMarket.Infrastructure;
using FTELMarket.Infrastructure.FTELMarket.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FTELMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly FtelMarketDbContext _context;

        public ProductsController(FtelMarketDbContext context)
        {
            _context = context;
        }

        [HttpGet("/products")]
        public IActionResult GetProducts()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return Ok(products);
        }

        [HttpPost("/products")]
        public IActionResult CreateProduct([FromBody] Product newProduct)
        {
            newProduct.CreatedAt = DateTime.UtcNow;
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return Ok(new { message = "Produit créé avec succès", product = newProduct });
        }
        [HttpPost("/categories")]
        public IActionResult CreateCategory([FromBody] Category newCategory)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return Ok(newCategory);
        }

        [HttpPut("/products/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound("Produit introuvable.");

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Stock = updatedProduct.Stock;
            product.Description = updatedProduct.Description;
            product.CategoryId = updatedProduct.CategoryId;

            _context.SaveChanges();
            return Ok(new { message = $"Le produit {id} a été modifié." });
        }

        [HttpDelete("/products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound("Produit introuvable.");

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(new { message = $"Le produit {id} a été supprimé." });
        }
    }
}