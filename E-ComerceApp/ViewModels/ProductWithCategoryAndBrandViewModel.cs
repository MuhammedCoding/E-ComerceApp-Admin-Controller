﻿using E_CommerceApp.Models;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceApp.ViewModels
{
    public class ProductWithCategoryAndBrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        [Display(Name = "Upload Image")]
        public IFormFile? ImageFile { get; set; }
        public int Count { get; set; }
        public int BrandId { get; set; }
        public List<Brand>? Brands { get; set; }
        public string? BrandName { get; set; }

        public string? BrandImage { get; set; }

        public string? CategoryImage { get; set; }


        public int CategoryId { get; set; }
        public List<Category>? Categories { get; set; }
        public string? CategoryName { get; set; }


    }
}
