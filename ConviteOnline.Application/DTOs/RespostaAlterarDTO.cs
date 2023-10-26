using System.ComponentModel.DataAnnotations;

namespace ConviteOnline.Application.DTOs
{
    public class RespostaAlterarDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Aniversario Id é requerido")]
        public string AniversarioId { get; set; }
        [Required(ErrorMessage = "Quantidade Adultos é requerido")]
        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        [Required(ErrorMessage = "Mensagem é requerido")]
        public string Mensagem { get; set; }
        [Required(ErrorMessage = "Marca Presença é requerido")]
        public bool MarcaPresenca { get; set; }
    }
}
