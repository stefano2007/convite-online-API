using Amazon.DynamoDBv2.DataModel;
using ConviteOnline.Domain.Entities;

namespace ConviteOnline.Infra.Data.EntitiesConfiguration
{
    [DynamoDBTable("fotosConviteOnline")]
    public class FotoDynamoDB
    {
        [DynamoDBHashKey("Id")]
        public string Id { get; set; }

        [DynamoDBProperty("aniversarioId")]
        public string AniversarioId { get; set; }

        [DynamoDBProperty("src")]
        public string Src { get; set; }

        [DynamoDBProperty("titulo")]
        public string Titulo { get; set; }

        [DynamoDBProperty("subtitulo")]
        public string SubTitulo { get; set; }

        [DynamoDBProperty("ordem")]
        public int Ordem { get; set; }

        public static implicit operator FotoDynamoDB(Foto foto)
        {
            if (foto != null)
            {
                return new FotoDynamoDB
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

        public static explicit operator Foto(FotoDynamoDB foto)
        {
            if (foto != null)
            {
                return new Foto(foto.Id, foto.AniversarioId, foto.Src, foto.Titulo, foto.SubTitulo, foto.Ordem);
            }
            return null;
        }
    }
}
