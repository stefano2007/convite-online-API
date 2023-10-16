using ConviteOnline.Domain.Validation;

namespace ConviteOnline.Domain.Entities
{
    public sealed class Resposta : Entidade
    {
        public int AniversarioId { get; private set; }
        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        public string Mensagem { get; set; }
        public bool MarcaPresenca { get; set; }
        public DateTime DataResposta { get; set;}
        public DateTime? Modificacao { get; set; }

        public Resposta(int aniversarioId, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime dataResposta, DateTime? modificacao)
        {
            ValidateDomain(aniversarioId, qtdAdultos, qtdCriancas, mensagem, marcaPresenca, dataResposta, modificacao);
        }
        public Resposta(int id, int aniversarioId, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime dataResposta, DateTime? modificacao)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(aniversarioId, qtdAdultos, qtdCriancas, mensagem, marcaPresenca, dataResposta, modificacao);
        }
        public void Update(int aniversarioId, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime dataResposta, DateTime modificacao)
        {
            ValidateDomain(aniversarioId, qtdAdultos, qtdCriancas, mensagem, marcaPresenca, dataResposta, modificacao);
        }
        private void ValidateDomain(int aniversarioId, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime dataResposta, DateTime? modificacao)
        {
            DomainExceptionValidation.When(aniversarioId <= 0,
                "Aniversario Id inválido, campo requerido");

            DomainExceptionValidation.When(qtdAdultos <= 0,
                "Quantidade Adultos inválido, campo requerido");

            DomainExceptionValidation.When(qtdCriancas < 0,
                "Quantidade Crianças inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(mensagem),
                "Titulo inválido, campo requerido");

            DomainExceptionValidation.When(dataResposta == DateTime.MinValue,
                "Data Resposta inválido, campo requerido");

            AniversarioId = aniversarioId;
            QtdAdultos = qtdAdultos;
            QtdCriancas = qtdCriancas;
            Mensagem = mensagem;
            MarcaPresenca = marcaPresenca;
            DataResposta = dataResposta;
            Modificacao = modificacao;
        }
    }
}
