namespace ConviteOnline.Application.DTOs
{
    public class RespostaDTO
    {
        public string Id { get; set; }
        public string AniversarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        public string Mensagem { get; set; }
        public bool MarcaPresenca { get; set; }
        public DateTime DataResposta { get; set; }
        public DateTime? DataModificacao { get; set; }
    }
}
