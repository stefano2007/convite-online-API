using ConviteOnline.Domain.Validation;

namespace ConviteOnline.Domain.Entities
{
    public sealed class Foto : Entidade
    {
        public int AniversarioId { get; private set; }
        public string Scr { get; private set; }
        public string Titulo { get; private set; }
        public string SubTitulo { get; private set; }
        public int Ordem { get; private set; }

        public Foto(int aniversarioId, string scr, string titulo, string subTitulo, int ordem)
        {
            ValidateDomain(aniversarioId, scr, titulo, subTitulo, ordem);
        }

        public Foto(int id, int aniversarioId, string scr, string titulo, string subTitulo, int ordem)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(aniversarioId, scr, titulo, subTitulo, ordem);
        }

        public void Update(int aniversarioId, string scr, string titulo, string subTitulo, int ordem)
        {
            ValidateDomain(aniversarioId, scr, titulo, subTitulo, ordem);
        }
        private void ValidateDomain(int aniversarioId, string scr, string titulo, string subTitulo, int ordem)
        {
            DomainExceptionValidation.When(aniversarioId <= 0,
                "Aniversario Id inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(scr),
                "Src inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo),
                "Titulo inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(subTitulo),
                "SubTitulo inválido, campo requerido");

            DomainExceptionValidation.When(ordem <= 0,
                "Ordem inválido, campo requerido");

            AniversarioId = aniversarioId;
            Scr = scr;
            Titulo = titulo;
            SubTitulo = subTitulo;
            Ordem = ordem;
        }
    }
}
