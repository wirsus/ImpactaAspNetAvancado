using System.ComponentModel.DataAnnotations;

namespace Empresa.Mvc.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Digite a senha!")]
        public string Senha { get; set; }
    }
}
