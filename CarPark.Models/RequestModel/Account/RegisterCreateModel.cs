using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Models.RequestModel.Account
{
    public class RegisterCreateModel
    {
        [Required(ErrorMessage ="Zorunlu")]
        [Display(Name = "UserName")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Zorunlu")]
        [EmailAddress(ErrorMessage = "Email adres formatında olması gerekiyor.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Zorunlu")]
        [StringLength(100, ErrorMessage = "Minimum 6 karakter olmak zorunda",  MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password" , ErrorMessage = "Şifreler Eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        public bool AcceptTerms { get; set; }
    }
}
