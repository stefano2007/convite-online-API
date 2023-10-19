using System.ComponentModel.DataAnnotations;

namespace ConviteOnline.Application.DTOs
{
    public class FotoCriarDTO
    {
        [Required(ErrorMessage = "Aniversario Id é requerido")]
        public string AniversarioId { get; set; }

        [Required(ErrorMessage = "Titulo é requerido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "SubTitulo é requerido")]
        public string SubTitulo { get; set; }

        [Required(ErrorMessage = "Ordem é requerido")]
        public int Ordem { get; set; }
    }
}
