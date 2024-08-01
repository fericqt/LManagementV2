using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Model {
    public class User {
        [Key]
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

        public DateTime Created { get; set; }
    }
}
