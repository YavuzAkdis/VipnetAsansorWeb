﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
