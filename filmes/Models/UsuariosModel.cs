using System.ComponentModel.DataAnnotations;

namespace filmes.Models
{
    public class UsuariosModel
    {
        [Key]
        public string Usuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;

    }
}
