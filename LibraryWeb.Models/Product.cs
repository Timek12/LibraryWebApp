﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LibraryWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Category Name")]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
