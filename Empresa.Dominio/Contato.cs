using System.ComponentModel.DataAnnotations;

namespace Empresa.Dominio
{
    public class Contato
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome!")]
        [MaxLength(100, ErrorMessage = "O nome deve ter até 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
    }
}
