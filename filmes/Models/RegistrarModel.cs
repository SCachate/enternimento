using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace filmes.Models
{
    public class RegistrarModel
    {
        [Required(ErrorMessage = "Informe o usuário!")]
        [Display(Name = "Usuário:")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a senha!")]
        [Display(Name = "Senha:")]
        [Compare("Confirmacao", ErrorMessage = "Senha e confirmação devem ser igual")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a confirmação da senha!")]
        [Display(Name = "Confirme a senha:")]
        [DataType(DataType.Password)]
        public string Confirmacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o nome do usuário!")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; } = string.Empty;

    }
}
