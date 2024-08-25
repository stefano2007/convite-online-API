using ConviteOnline.Domain.Validation;

namespace ConviteOnline.Domain.Entities
{
    public sealed class Resposta : Entidade
    {
        public string AniversarioId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public int QtdAdultos { get; private set; }
        public int QtdCriancas { get; private set; }
        public string Mensagem { get; private set; }
        public bool MarcaPresenca { get; private set; }
        public DateTime DataResposta { get; private set; }
        public DateTime? DataModificacao { get; private set; }

        public Resposta(string aniversarioId, string nome, string email, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime? dataModificacao)
        {
            ValidateDomain(aniversarioId, nome, email, qtdAdultos, qtdCriancas, mensagem, marcaPresenca, dataModificacao);
        }
        public Resposta(string id, string aniversarioId, string nome, string email, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime dataResposta, DateTime? dataModificacao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(id), "Id inválido.");

            DomainExceptionValidation.When(dataResposta == DateTime.MinValue,
                "Data Resposta inválido, campo requerido");
            Id = id;
            DataResposta = dataResposta;
            ValidateDomain(aniversarioId, nome, email, qtdAdultos, qtdCriancas, mensagem, marcaPresenca, dataModificacao);
        }
        public void Update(string aniversarioId, string nome, string email, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime? dataModificacao)
        {
            ValidateDomain(aniversarioId, nome, email, qtdAdultos, qtdCriancas, mensagem, marcaPresenca, dataModificacao);
        }
        private void ValidateDomain(string aniversarioId, string nome, string email, int qtdAdultos, int qtdCriancas, string mensagem, bool marcaPresenca, DateTime? dataModificacao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(aniversarioId),
                "Aniversario Id inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
               "Nome inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                "E-mail inválido, campo requerido");

            DomainExceptionValidation.When(qtdAdultos <= 0,
                "Quantidade Adultos inválido, campo requerido");

            DomainExceptionValidation.When(qtdCriancas < 0,
                "Quantidade Crianças inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(mensagem),
                "Mensagem inválido, campo requerido");

            AniversarioId = aniversarioId;
            Nome = nome;
            Email = email;
            QtdAdultos = qtdAdultos;
            QtdCriancas = qtdCriancas;
            Mensagem = mensagem;
            MarcaPresenca = marcaPresenca;
            DataModificacao = dataModificacao;
        }
    }
}
