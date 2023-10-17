using System.ComponentModel.DataAnnotations;

namespace academia.Application.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "E-mail é obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        public string? Email { get; set; }
    }
}
