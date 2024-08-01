using System.ComponentModel.DataAnnotations;

namespace LManagement.Model {
    public class Category {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}
