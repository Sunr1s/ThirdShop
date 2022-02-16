using System.ComponentModel.DataAnnotations; 

namespace ThirdShop.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}