using Amazon.DynamoDBv2.DataModel;
using ConviteOnline.Domain.Entities;

namespace ConviteOnline.Infra.Data.EntitiesConfiguration
{
    [DynamoDBTable("respostasConviteOnline")]
    public class RespostaDynamoDB
    {
        [DynamoDBHashKey("id")]
        public string Id { get; set; }
        [DynamoDBProperty("aniversarioId")]        
        public string AniversarioId { get; set; }
        [DynamoDBProperty("nome")]
        public string Nome { get; set; }
        [DynamoDBProperty("email")]
        public string Email { get; set; }
        [DynamoDBProperty("qtdAdultos")]
        public int QtdAdultos { get; set; }
        [DynamoDBProperty("qtdCriancas")]
        public int QtdCriancas { get; set; }
        [DynamoDBProperty("mensagem")]
        public string Mensagem { get; set; }
        [DynamoDBProperty("marcaPresenca")]
        public bool MarcaPresenca { get; set; }
        [DynamoDBProperty("dataResposta")]
        public DateTime DataResposta { get; set; }
        [DynamoDBProperty("dataModificacao")]
        public DateTime? DataModificacao { get; set; }

        public static implicit operator RespostaDynamoDB(Resposta resposta)
        {
            if (resposta != null)
            {
                return new RespostaDynamoDB
                {
                    Id = resposta.Id,
                    AniversarioId = resposta.AniversarioId,
                    Nome = resposta.Nome,
                    Email = resposta.Email,
                    QtdAdultos = resposta.QtdAdultos,
                    QtdCriancas = resposta.QtdCriancas,
                    Mensagem = resposta.Mensagem,
                    MarcaPresenca = resposta.MarcaPresenca,
                    DataResposta = resposta.DataResposta,
                    DataModificacao = resposta.DataModificacao
                };
            }
            return null;
        }

        public static explicit operator Resposta(RespostaDynamoDB resposta)
        {
            if (resposta != null)
            {
                return new Resposta(resposta.Id, resposta.AniversarioId, resposta.Nome, resposta.Email, resposta.QtdAdultos, resposta.QtdCriancas,
                    resposta.Mensagem, resposta.MarcaPresenca, resposta.DataResposta, resposta.DataModificacao);
            }
            return null;
        }
    }
}
