using System.ComponentModel.DataAnnotations;

namespace hackweek_backend.Dtos
{
    public class TagDtoCreate
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(100,ErrorMessage = "A descrição não pode exceder 100 caracteres.")]
        public string Description { get; set; } = string.Empty;
    }
}
