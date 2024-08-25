using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime.Internal;
using ConviteOnline.Domain.Entities;
using ConviteOnline.Domain.Interfaces;
using ConviteOnline.Infra.Data.EntitiesConfiguration;

namespace ConviteOnline.Infra.Data.Repositories
{
    public class RespostaRepositorio : IRespostaRepositorio
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public RespostaRepositorio(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public async Task<Resposta> AlterarAsync(Resposta resposta, CancellationToken cancellation)
        {
            var respostaDB = (Resposta)await _dynamoDBContext.LoadAsync<RespostaDynamoDB>(resposta.Id, cancellation);
            respostaDB.Update(resposta.AniversarioId, resposta.Nome, resposta.Email, resposta.QtdAdultos, resposta.QtdCriancas,
            resposta.Mensagem, resposta.MarcaPresenca, resposta.DataModificacao);

            var respostaDBUpdate = (RespostaDynamoDB)respostaDB;

            await _dynamoDBContext.SaveAsync<RespostaDynamoDB>(respostaDBUpdate, cancellation);
            return (Resposta)respostaDBUpdate;
        }

        public async Task<Resposta> CriarAsync(Resposta obj, CancellationToken cancellation)
        {
            var respostaDynamoDB = (RespostaDynamoDB)obj;
            await _dynamoDBContext.SaveAsync<RespostaDynamoDB>(respostaDynamoDB, cancellation);
            return (Resposta)respostaDynamoDB;
        }
        public async Task<Resposta> DeletaAsync(Resposta obj, CancellationToken cancellation)
        {
            var respostaDynamoDB = (RespostaDynamoDB)obj;
            await _dynamoDBContext.DeleteAsync<RespostaDynamoDB>(respostaDynamoDB, cancellation);
            return (Resposta)respostaDynamoDB;
        }
        public async Task<Resposta> ObterPorIdAsync(string id, CancellationToken cancellation)
        {
            var respostaDynamoDB = await _dynamoDBContext.LoadAsync<RespostaDynamoDB>(id, cancellation);

            var resposta = (Resposta)respostaDynamoDB;
            return resposta;
        }
        public async Task<IEnumerable<Resposta>> ObterPorAniversarioIdAsync(string aniversarioId, CancellationToken cancellation)
        {
            List<ScanCondition> conditions = new List<ScanCondition>();
            conditions.Add(new ScanCondition("AniversarioId", ScanOperator.Equal, aniversarioId));

            var search = _dynamoDBContext.ScanAsync<RespostaDynamoDB>(conditions);
            var searchResponse = await search.GetRemainingAsync(cancellation);

            return searchResponse.Select(f => (Resposta)f);
        }
    }
}
