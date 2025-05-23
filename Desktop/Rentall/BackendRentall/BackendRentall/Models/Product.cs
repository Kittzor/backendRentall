﻿using System.ComponentModel.DataAnnotations;

namespace BackendRentall.Models
{

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public string? BookedBy { get; set; }

    }

}
