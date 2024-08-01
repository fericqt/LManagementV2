using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Model {
    public class SalesDetail {
        [Key]
        public int Id { get; set; }
        public int SalesHeaderId { get; set; }
        [ForeignKey(nameof(SalesHeaderId))]
        public SalesHeader SalesHeader { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public double SalesQty { get; set; }
        public double SalesPrice { get; set; }
        public decimal SalesDiscount { get; set; }

    }
}
