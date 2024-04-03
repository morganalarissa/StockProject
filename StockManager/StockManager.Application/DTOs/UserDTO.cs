using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(250, ErrorMessage ="Name cant have more than 250 caracter")]
        public string Name { get;  set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(250, ErrorMessage = "Email cant have more than 250 caracter")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(100, ErrorMessage = "Password cant have more than 100 caracter")]
        [MinLength(8, ErrorMessage = "Password has more than 8 caracteres")]
        [NotMapped]
        public string Password { get; set; }
    }
}
