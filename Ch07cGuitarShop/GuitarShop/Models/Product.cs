﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GuitarShop.Models
{
    public class Product
    {
        // EF will instruct the database to automatically generate this value
        public int ProductID { get; set; }

      // foreign key property

        [Required(ErrorMessage = "Please enter a BusinessName.")]
       public string BusinessName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a BusinessAddress.")]
       public string BusinessAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a BusinessEmail.")]
       public string BusinessEmail { get; set; } = string.Empty;

       [Required(ErrorMessage = "Please enter a BusinessPhone.")]
       public int BusinessPhone { get; set; } 

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; } 


        // [Required(ErrorMessage = "Please enter a product price.")]
        // [Column(TypeName = "decimal(18,2)")]
        // public decimal Price { get; set; }

        // public decimal DiscountPercent => .20M;  // A discount of 20% is hard-coded for all products

        // public decimal DiscountAmount => Price * DiscountPercent;

        // public decimal DiscountPrice => Price - DiscountAmount;

        // public string Slug => Name.Replace(' ', '-');

        [ValidateNever]
        public Category Category { get; set; } = null!;

    }
}