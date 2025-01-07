using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace filmes.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o usuário!")]
        [Display(Name = "Usuário:")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a senha!")]
        [Display(Name = "Senha:")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;

        [Display(Name = "Lembrar me")]
        public bool LembrarMe { get; set; }
    }
}
