using System.ComponentModel.DataAnnotations;

namespace academia.Application.Models.Account
{
    public class UserViewModel
    {
        [Display(Name = "Primeiro nome")]
        [Required(ErrorMessage = "O Primeiro nome é obrigatorio")]
        public string? FirstName { get; set; }

        [Display(Name = "Último nome")]
        [Required(ErrorMessage = "O Último nome é obrigatorio")]
        public string? LastName { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O Usuário é obrigatorio")]
        public string? UserName { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Required(ErrorMessage = "O E-mail é obrigatorio")]
        public string? Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatoria")]
        public string? Password { get; set; }

        [Display(Name = "Confirme a senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        [Required(ErrorMessage = "Confirme a senha é obrigatório")]
        public string? ConfirmPassword { get; set; }
    }
}
