﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Model {
    public class ProductImage {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
