using ConviteOnline.Domain.Validation;

namespace ConviteOnline.Domain.Entities
{
    public sealed class Aniversario : Entidade
    {        
        public string Slug { get; private set; }//gera url amigavel
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Descricao { get; private set; }
        public string Titulo { get; private set; }
        public string Informativos { get; private set; }
        public DateOnly DataAniversario { get; private set; }
        public DateOnly DataEvento { get; private set; }
        public string HorarioEvento { get; private set; }
        public string Local { get; private set; }
        public string Endereco { get; private set; }
        public string LocalizacaoUrl { get; private set; }
        public string ImagemConvite { get; private set; }
        public DateOnly DataLimiteConfirmaPresenca { get; private set; }
        public List<Foto> FotosDestaque { get; private set; }
        public List<Foto> FotosCarrossel { get; private set; }
        public List<Foto> Fotos { get; private set; }
        public List<Resposta> Respostas { get; private set; }

        public void AdicionarFotoDestaque(Foto fotoDestaque)
        {
            FotosDestaque = FotosDestaque ?? new List<Foto>();

            DomainExceptionValidation.When( FotosDestaque.Count >= 6,
                "Limite de até 6 Fotos em Destaque atingido.");

            FotosDestaque.Add(fotoDestaque);
        }

        public void RemoverFotoDestaque(Foto fotoDestaque)
        {
            FotosDestaque = FotosDestaque ?? new List<Foto>();

            DomainExceptionValidation.When(fotoDestaque == null,
               "Não foi possivel localizar a foto para excluir.");

            FotosDestaque.Remove(fotoDestaque);
        }

        public void AdicionarFotoCarrossel(Foto fotoCarrossel)
        {
            FotosCarrossel = FotosCarrossel ?? new List<Foto>();

            DomainExceptionValidation.When(FotosCarrossel.Count >= 20,
                "Limite de até 20 Fotos no Carrossel atingido.");

            FotosCarrossel.Add(fotoCarrossel);
        }

        public void RemoverFotoCarrossel(Foto fotoCarrossel)
        {
            FotosCarrossel = FotosCarrossel ?? new List<Foto>();

            DomainExceptionValidation.When(fotoCarrossel == null,
               "Não foi possivel localizar a foto para excluir.");

            FotosCarrossel.Remove(fotoCarrossel);
        }

        public void AlterarImagemConvite(string imagemConvite)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(imagemConvite),
                "Imagem Convite inválido, campo requerido");

            ImagemConvite = imagemConvite;
        }

        public void RemoverImagemConvite()
        {
            ImagemConvite = string.Empty;
        }

        public Aniversario(string slug, string nome, int idade, string descricao, string titulo, 
            string informativos, DateOnly dataAniversario, DateOnly dataEvento, string horarioEvento, string local,
            string endereco, string localizacaoUrl, DateOnly dataLimiteConfirmaPresenca)
        {
            ValidateDomain(slug, nome, idade, descricao, titulo, informativos,
                dataAniversario, dataEvento, horarioEvento, local, endereco, localizacaoUrl, 
                dataLimiteConfirmaPresenca);
        }

        public Aniversario(string id, string slug, string nome, int idade, string descricao, string titulo,
            string informativos, DateOnly dataAniversario, DateOnly dataEvento, string horarioEvento, string local,
            string endereco, string localizacaoUrl, DateOnly dataLimiteConfirmaPresenca)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(id), "Id inválido.");
            Id = id;
            ValidateDomain(slug, nome, idade, descricao, titulo, informativos,
                dataAniversario, dataEvento, horarioEvento, local, endereco, localizacaoUrl,
                dataLimiteConfirmaPresenca);
        }

        public void Update(string slug, string nome, int idade, string descricao, string titulo,
            string informativos, DateOnly dataAniversario, DateOnly dataEvento, string horarioEvento, string local,
            string endereco, string localizacaoUrl, DateOnly dataLimiteConfirmaPresenca)
        {
            ValidateDomain(slug, nome, idade, descricao, titulo, informativos,
                dataAniversario, dataEvento, horarioEvento, local, endereco, localizacaoUrl,
                dataLimiteConfirmaPresenca);
        }

        private void ValidateDomain(string slug, string nome, int idade, string descricao, string titulo,
            string informativos, DateOnly dataAniversario, DateOnly dataEvento, string horarioEvento, string local,
            string endereco, string localizacaoUrl, DateOnly dataLimiteConfirmaPresenca)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(slug),
                "SLUG inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Titulo inválido, campo requerido");

            DomainExceptionValidation.When(idade <= 0,
               "Idade inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo),
                "Titulo inválido, campo requerido");

            DomainExceptionValidation.When(dataAniversario == DateOnly.MinValue,
                "Data Aniversario inválido, campo requerido");

            DomainExceptionValidation.When(dataEvento == DateOnly.MinValue,
                "Data Evento inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(horarioEvento),
               "Horário Evento inválido, campo requerido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco),
               "Endereço inválido, campo requerido");

            DomainExceptionValidation.When(dataLimiteConfirmaPresenca == DateOnly.MinValue,
                "Data Limite de Confirma a Presença inválido, campo requerido");

            Slug = slug;
            Nome = nome;
            Idade = idade;
            Descricao = descricao;
            Titulo = titulo;
            Informativos = informativos;
            DataAniversario = dataAniversario;
            DataEvento = dataEvento;
            HorarioEvento = horarioEvento;
            Local = local;
            Endereco = endereco;
            LocalizacaoUrl = localizacaoUrl;
            DataLimiteConfirmaPresenca = dataLimiteConfirmaPresenca;
        }
    }
}
