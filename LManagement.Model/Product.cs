using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Model {
    public class Product {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public double RetailPrice { get; set; }
        public double CostPrice { get; set; }
        public double InventoryQty { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ProductStatus { get; set; }

        public DateTime DateCreated { get; set; }
        public int ProductImageId { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}
