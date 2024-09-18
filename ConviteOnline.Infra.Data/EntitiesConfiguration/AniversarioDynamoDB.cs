using Amazon.DynamoDBv2.DataModel;
using ConviteOnline.Domain.Entities;

namespace ConviteOnline.Infra.Data.EntitiesConfiguration
{
    [DynamoDBTable("aniversariosConviteOnline")]
    public class AniversarioDynamoDB
    {
        [DynamoDBHashKey("id")]
        public string Id { get; set; }

        [DynamoDBProperty("slug")]
        public string Slug { get; set; }

        [DynamoDBProperty("nome")]
        public string Nome { get; set; }

        [DynamoDBProperty("idade")]
        public int Idade { get; set; }

        [DynamoDBProperty("descricao")]
        public string Descricao { get; set; }

        [DynamoDBProperty("titulo")]
        public string Titulo { get; set; }

        [DynamoDBProperty("informativos")]
        public string Informativos { get; set; }

        [DynamoDBProperty("dataAniversario")]
        public DateTime DataAniversario { get; set; }

        [DynamoDBProperty("dataEvento")]
        public DateTime DataEvento { get; set; }

        [DynamoDBProperty("horarioEvento")]
        public string HorarioEvento { get; set; }

        [DynamoDBProperty("local")]
        public string Local { get; set; }

        [DynamoDBProperty("endereco")]
        public string Endereco { get; set; }

        [DynamoDBProperty("localizacaoUrl")]
        public string LocalizacaoUrl { get; set; }

        [DynamoDBProperty("imagemConvite")]
        public string ImagemConvite { get; set; }
        [DynamoDBProperty("dataLimiteConfirmaPresenca")]
        public DateTime DataLimiteConfirmaPresenca { get; set; }
        [DynamoDBProperty("fotosDestaque")]
        public FotoDetail[] FotosDestaque { get; set; }
        [DynamoDBProperty("fotosCarrossel")]
        public FotoDetail[] FotosCarrossel { get; set; }


        public static implicit operator AniversarioDynamoDB(Aniversario aniversario)
        {
            if (aniversario != null)
            {
                return new AniversarioDynamoDB
                {
                    Id = aniversario.Id,
                    Slug = aniversario.Slug,
                    Nome = aniversario.Nome,
                    Idade = aniversario.Idade,
                    Descricao = aniversario.Descricao,
                    Titulo = aniversario.Titulo,
                    Informativos = aniversario.Informativos,
                    DataAniversario = DateTime.Parse(aniversario.DataAniversario.ToShortDateString()),
                    DataEvento = DateTime.Parse(aniversario.DataEvento.ToShortDateString()),
                    HorarioEvento = aniversario.HorarioEvento,
                    Local = aniversario.Local,
                    Endereco = aniversario.Endereco,
                    LocalizacaoUrl = aniversario.LocalizacaoUrl,
                    ImagemConvite = aniversario.ImagemConvite,
                    DataLimiteConfirmaPresenca = DateTime.Parse(aniversario.DataLimiteConfirmaPresenca.ToShortDateString()),
                    FotosDestaque = aniversario.FotosDestaque?.Select(x => (FotoDetail)x).ToArray(),
                    FotosCarrossel = aniversario.FotosCarrossel?.Select(x => (FotoDetail)x).ToArray(),
                };
            }
            return null;
        }

        public static explicit operator Aniversario(AniversarioDynamoDB aniversario)
        {
            if (aniversario != null)
            {
                var aniver =  new Aniversario(aniversario.Id, aniversario.Slug, aniversario.Nome, aniversario.Idade, aniversario.Descricao, aniversario.Titulo, 
                    aniversario.Informativos, DateOnly.FromDateTime(aniversario.DataAniversario), DateOnly.FromDateTime(aniversario.DataEvento), 
                    aniversario.HorarioEvento, aniversario.Local, aniversario.Endereco, aniversario.LocalizacaoUrl, DateOnly.FromDateTime(aniversario.DataLimiteConfirmaPresenca));

                if (aniversario.FotosDestaque is not null)
                {
                    foreach (var item in aniversario.FotosDestaque)
                    {
                        aniver.AdicionarFotoDestaque((Foto)item);
                    }
                }                

                if (aniversario.FotosCarrossel is not null)
                {
                    foreach (var item in aniversario.FotosCarrossel)
                    {
                        aniver.AdicionarFotoCarrossel((Foto)item);
                    }
                }

                if (!string.IsNullOrEmpty(aniversario.ImagemConvite))
                {
                    aniver.AlterarImagemConvite(aniversario.ImagemConvite);
                }

                return aniver;
            }
            return null;
        }
    }

    public class FotoDetail
    {
        public string Id { get; set; }
        public string AniversarioId { get; set; }
        public string Src { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }

        public int Ordem { get; set; }

        public static implicit operator FotoDetail(Foto foto)
        {
            if (foto != null)
            {
                return new FotoDetail
                {
                    Id = foto.Id,
                    AniversarioId = foto.AniversarioId,
                    Src = foto.Src,
                    Titulo = foto.Titulo,
                    SubTitulo = foto.SubTitulo,
                    Ordem = foto.Ordem
                };
            }
            return null;
        }

        public static explicit operator Foto(FotoDetail foto)
        {
            if (foto != null)
            {
                return new Foto(foto.Id, foto.AniversarioId, foto.Src, foto.Titulo, foto.SubTitulo, foto.Ordem);
            }
            return null;
        }
    }
}
