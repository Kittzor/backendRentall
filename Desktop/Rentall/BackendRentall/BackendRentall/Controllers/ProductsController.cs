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
            // Check if the product is null
            if (product == null)
            {
                return BadRequest(new { message = "Invalid product data" });
            }

            // Check if an image file was uploaded
            if (image != null && image.Length > 0)
            {
                // Define the path to save the image (create a folder if it doesn't exist)
                var uploadsFolder = Path.Combine("wwwroot", "images", image.FileName);
                Directory.CreateDirectory(uploadsFolder);

                // Generate a unique file name to avoid conflicts
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                // Combine the folder path with the unique file name
                var filePath = Path.Combine(uploadsFolder, uniqueFileName); 
                
                // Copy the uploaded image to the server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                // Set the image URL in the product object
                product.ImageUrl = $"/images/{uniqueFileName}";
            }

            // Add the product to the database
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            // Return the created product with a 201 Created status
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
    }
}