using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } // Şifreler genellikle hashlenmiş olarak saklanır
        [NotMapped]
        public string? ErrorMessage { get; set; }
        public string? Role { get; set; } // Kullanıcının rolü (Admin, User vs.)
    }
}
