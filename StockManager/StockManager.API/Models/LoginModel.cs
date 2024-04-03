﻿using System.ComponentModel.DataAnnotations;

namespace StockManager.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}
