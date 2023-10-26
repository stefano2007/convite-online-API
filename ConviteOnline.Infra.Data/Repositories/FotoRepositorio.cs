using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using ConviteOnline.Domain.Entities;
using ConviteOnline.Domain.Interfaces;
using ConviteOnline.Infra.Data.EntitiesConfiguration;

namespace ConviteOnline.Infra.Data.Repositories
{
    public class FotoRepositorio : IFotoRepositorio
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        public FotoRepositorio(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }
        public async Task<Foto> AlterarAsync(Foto obj, CancellationToken cancellation)
        {
            var fotoDB = (Foto) await _dynamoDBContext.LoadAsync<FotoDynamoDB>(obj.Id, cancellation);
            fotoDB.Update(obj.AniversarioId, obj.Titulo, obj.SubTitulo, obj.Ordem);

            var fotoDBUpdate = (FotoDynamoDB)fotoDB;

            await _dynamoDBContext.SaveAsync<FotoDynamoDB>(fotoDBUpdate, cancellation);
            return (Foto) fotoDBUpdate;
        }
        public async Task<Foto> CriarAsync(Foto obj, CancellationToken cancellation)
        {
            var fotoDynamoDB = (FotoDynamoDB)obj;
            await _dynamoDBContext.SaveAsync<FotoDynamoDB>(fotoDynamoDB, cancellation);
            return (Foto) fotoDynamoDB;
        }
        public async Task<Foto> DeletaAsync(Foto obj, CancellationToken cancellation)
        {
            var fotoDynamoDB = (FotoDynamoDB)obj;
            await _dynamoDBContext.DeleteAsync<FotoDynamoDB>(fotoDynamoDB, cancellation);
            return (Foto)fotoDynamoDB;
        }
        public async Task<Foto> ObterPorIdAsync(string id, CancellationToken cancellation)
        {
            var fotoDynamoDB = await _dynamoDBContext.LoadAsync<FotoDynamoDB>(id, cancellation);

            var foto = (Foto) fotoDynamoDB;
            return foto;
        }
        public async Task<IEnumerable<Foto>> ObterPorAniversarioIdAsync(string aniversarioId, CancellationToken cancellation)
        {
            List<ScanCondition> conditions = new List<ScanCondition>();
            conditions.Add(new ScanCondition("AniversarioId", ScanOperator.Equal, aniversarioId));

            var search = _dynamoDBContext.ScanAsync<FotoDynamoDB>(conditions);
            var searchResponse = await search.GetRemainingAsync(cancellation);

            return searchResponse.Select(f => (Foto) f);
        }
    }
}
