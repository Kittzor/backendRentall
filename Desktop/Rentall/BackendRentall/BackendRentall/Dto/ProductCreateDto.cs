using System.ComponentModel.DataAnnotations;

namespace BackendRentall.Dto
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, 999999)]
        public decimal Price { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        public string CreatedBy { get; set; }
    }
}
