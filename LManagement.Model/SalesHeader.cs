using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Model {
    public class SalesHeader {
        [Key]
        public int Id { get; set; }
        public string TransactionID { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int UserID { get; set; }
        public string SalesStatus { get; set; }
        public string TransactionStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime SalesDate { get; set; }
        public DateTime TransactionDate { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }


    }
}
