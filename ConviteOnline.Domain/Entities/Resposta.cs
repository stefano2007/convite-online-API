using ConviteOnline.Domain.Validation;

namespace ConviteOnline.Domain.Entities
{
    public sealed class Resposta : Entidade
    {
        public string AniversarioId { get; private set; }
        public int QtdAdultos { get; private set; }
        public int QtdCriancas { get; private set; }
        public string Mensagem { get; private set; }
        public bool MarcaPresenca { get; private set; }
        public DateTime DataResposta { get; protected set; }
        public DateTime? DataModificacao { get; private set; }

        public Resposta(string aniversarioId, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime? dataModificacao)
        {
            ValidateDomain(aniversarioId, qtdAdultos, qtdCriancas, mensagem, marcaPresenca, dataModificacao);
        }
        public Resposta(string id, string aniversarioId, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime dataResposta, DateTime? dataModificacao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(id), "Id inválido.");

            DomainExceptionValidation.When(dataResposta == DateTime.MinValue,
                "Data Resposta inválido, campo requerido");
            Id = id;
            DataResposta = dataResposta;
            ValidateDomain(aniversarioId, qtdAdultos, qtdCriancas, mensagem, marcaPresenca, dataModificacao);
        }
        public void Update(string aniversarioId, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime? dataModificacao)
        {
            ValidateDomain(aniversarioId, qtdAdultos, qtdCriancas, mensagem, marcaPresenca, dataModificacao);
        }
        private void ValidateDomain(string aniversarioId, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime? dataModificacao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(aniversarioId),
                "Aniversario Id inválido, campo requerido");

            DomainExceptionValidation.When(qtdAdultos <= 0,
                "Quantidade Adultos inválido, campo requerido");

            DomainExceptionValidation.When(qtdCriancas < 0,
                "Quantidade Crianças inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(mensagem),
                "Titulo inválido, campo requerido");

            AniversarioId = aniversarioId;
            QtdAdultos = qtdAdultos;
            QtdCriancas = qtdCriancas;
            Mensagem = mensagem;
            MarcaPresenca = marcaPresenca;
            DataModificacao = dataModificacao;
        }
    }
}
