namespace ConviteOnline.Application.DTOs
{
    public class AniversarioDTO
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public string Informativos { get; set; }
        public DateOnly DataAniversario { get; set; }
        public DateOnly DataEvento { get; set; }
        public string HorarioEvento { get; set; }
        public string Endereco { get; set; }
        public string LocalizacaoUrl { get; set; }
        public string ImagemConvite { get; set; }
        public DateOnly DataLimiteConfirmaPresenca { get; set; }
        public List<FotoDTO> FotosDestaque { get; set; }
        public List<FotoDTO> FotosCarrossel { get; set; }
    }
}
