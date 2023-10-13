using System.ComponentModel.DataAnnotations;

namespace academia.Application.Models.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O Usuário é obrigatorio")]
        public string? UserName { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatoria")]
        public string? Password { get; set; }
    }
}
