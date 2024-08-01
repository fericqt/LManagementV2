using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Model {
    public class Address {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public int CustomerId { get; set; } 
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

    }
}
