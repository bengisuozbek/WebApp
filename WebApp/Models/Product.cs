﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
	public class Product
	{
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

