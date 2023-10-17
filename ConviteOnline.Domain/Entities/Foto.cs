using ConviteOnline.Domain.Validation;

namespace ConviteOnline.Domain.Entities
{
    public sealed class Foto : Entidade
    {
        public string AniversarioId { get; private set; }
        public string Src { get; private set; }
        public string Titulo { get; private set; }
        public string SubTitulo { get; private set; }
        public int Ordem { get; private set; }

        public Foto(string aniversarioId, string src, string titulo, string subTitulo, int ordem)
        {
            ValidateDomain(aniversarioId, src, titulo, subTitulo, ordem);
        }

        public Foto(string id, string aniversarioId, string src, string titulo, string subTitulo, int ordem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(id), "Id inválido.");
            Id = id;
            ValidateDomain(aniversarioId, src, titulo, subTitulo, ordem);
        }

        public void Update(string aniversarioId, string src, string titulo, string subTitulo, int ordem)
        {
            ValidateDomain(aniversarioId, src, titulo, subTitulo, ordem);
        }
        private void ValidateDomain(string aniversarioId, string src, string titulo, string subTitulo, int ordem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(src),
                "Aniversario Id inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(src),
                "Src inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo),
                "Titulo inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(subTitulo),
                "SubTitulo inválido, campo requerido");

            DomainExceptionValidation.When(ordem <= 0,
                "Ordem inválido, campo requerido");

            AniversarioId = aniversarioId;
            Src = src;
            Titulo = titulo;
            SubTitulo = subTitulo;
            Ordem = ordem;
        }
    }
}
