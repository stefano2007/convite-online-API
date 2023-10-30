using System.ComponentModel.DataAnnotations;

namespace ConviteOnline.Application.DTOs
{
    public class AniversarioCriarDTO
    {
        [Required(ErrorMessage = "Slug é requerido")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "Nome é requerido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Idade é requerido")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Descrição é requerido")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Título é requerido")]
        public string Titulo { get; set; }
        public string Informativos { get; set; }
        [Required(ErrorMessage = "Data Aniversário é requerido")]
        public DateOnly DataAniversario { get; set; }
        [Required(ErrorMessage = "Data Evento é requerido")]
        public DateOnly DataEvento { get; set; }
        [Required(ErrorMessage = "Slug é requerido")]
        public string HorarioEvento { get; set; }
        [Required(ErrorMessage = "Horário Evento é requerido")]
        public string Endereco { get; set; }
        public string LocalizacaoUrl { get; set; }
        [Required(ErrorMessage = "Data Limite Confirma Presença é requerido")]
        public DateOnly DataLimiteConfirmaPresenca { get; set; }
    }
}
