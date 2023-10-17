using System.ComponentModel.DataAnnotations;

namespace academia.Application.Models.Account
{
    public class ResetPasswordViewModel
    {
        public string? Token { get; set; }

        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatoria")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirme senha é obrigatoria")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais")]
        public string? ConfirmPassword { get; set; }

    }
}
