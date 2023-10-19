namespace ConviteOnline.Application.DTOs
{
    public class RespostaAlterarDTO
    {
        public string Id { get; set; }
        public string AniversarioId { get; set; }
        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        public string Mensagem { get; set; }
        public bool MarcaPresenca { get; set; }
    }
}
