using System.ComponentModel.DataAnnotations;

namespace hackweek_backend.Models
{
    public class Tag
    {
        public uint Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(100, ErrorMessage = "A descrição não pode exceder 100 caracteres.")]
        public string Description { get; set; } = string.Empty;
    }
}
