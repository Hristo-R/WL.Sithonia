﻿namespace WL.Sithonia.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateModel
    {
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }
    }
}
