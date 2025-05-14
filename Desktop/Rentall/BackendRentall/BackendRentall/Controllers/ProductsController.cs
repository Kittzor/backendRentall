using Microsoft.AspNetCore.Mvc;
using BackendRentall.Models;
using BackendRentall.Data;
using Microsoft.EntityFrameworkCore;


namespace BackendRentall.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromForm] Product product, [FromForm] IFormFile image)
        {
            if (product == null)
            {
                return BadRequest(new { message = "Invalid product data" });
            }

            if (image != null && image.Length > 0)
            {
                var filePath = Path.Combine("wwwroot", "images", image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                product.ImageUrl = $"/images/{image.FileName}";
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
    }
}