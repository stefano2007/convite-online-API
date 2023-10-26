using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using ConviteOnline.Domain.Entities;
using ConviteOnline.Domain.Interfaces;
using ConviteOnline.Infra.Data.EntitiesConfiguration;

namespace ConviteOnline.Infra.Data.Repositories
{
    public class AniversarioRepositorio : IAniversarioRepositorio
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public AniversarioRepositorio(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public async Task<Foto> AdicionarFotoCarrosselAsync(Foto obj, CancellationToken cancellation)
        {
            var aniversarioDB = (Aniversario)await _dynamoDBContext.LoadAsync<AniversarioDynamoDB>(obj.AniversarioId, cancellation);

            aniversarioDB.AdicionarFotoCarrossel(obj);

            var aniversarioDBUpdate = (AniversarioDynamoDB)aniversarioDB;

            await _dynamoDBContext.SaveAsync<AniversarioDynamoDB>(aniversarioDBUpdate, cancellation);
            return (Foto)obj;
        }

        public async Task<Foto> AdicionarFotoDestaqueAsync(Foto obj, CancellationToken cancellation)
        {
            var aniversarioDB = (Aniversario)await _dynamoDBContext.LoadAsync<AniversarioDynamoDB>(obj.AniversarioId, cancellation);

            aniversarioDB.AdicionarFotoDestaque(obj);

            var aniversarioDBUpdate = (AniversarioDynamoDB)aniversarioDB;

            await _dynamoDBContext.SaveAsync<AniversarioDynamoDB>(aniversarioDBUpdate, cancellation);
            return (Foto)obj;
        }

        public async Task<Aniversario> AlterarAsync(Aniversario obj, CancellationToken cancellation)
        {
            var aniversarioDB = (Aniversario)await _dynamoDBContext.LoadAsync<AniversarioDynamoDB>(obj.Id, cancellation);
            aniversarioDB.Update(obj.Slug, obj.Nome, obj.Idade, obj.Descricao, obj.Titulo, obj.Informativos,
                obj.DataAniversario, obj.DataEvento, obj.HorarioEvento, obj.Endereco, obj.LocalizacaoUrl,
                obj.ImagemConvite, obj.DataLimiteConfirmaPresenca);

            var aniversarioDBUpdate = (AniversarioDynamoDB)aniversarioDB;

            aniversarioDBUpdate.FotosDestaque = obj.FotosDestaque?.Select(f => (FotoDetail)f).ToArray();
            aniversarioDBUpdate.FotosCarrossel = obj.FotosCarrossel?.Select(f => (FotoDetail)f).ToArray();

            await _dynamoDBContext.SaveAsync<AniversarioDynamoDB>(aniversarioDBUpdate, cancellation);
            return (Aniversario)aniversarioDBUpdate;
        }


        public async Task<Aniversario> CriarAsync(Aniversario obj, CancellationToken cancellation)
        {
            var aniversarioDynamoDB = (AniversarioDynamoDB)obj;
            await _dynamoDBContext.SaveAsync<AniversarioDynamoDB>(aniversarioDynamoDB, cancellation);
            return (Aniversario)aniversarioDynamoDB;
        }
        public async Task<Aniversario> DeletaAsync(Aniversario obj, CancellationToken cancellation)
        {
            var aniversarioDynamoDB = (AniversarioDynamoDB)obj;
            await _dynamoDBContext.DeleteAsync<AniversarioDynamoDB>(aniversarioDynamoDB, cancellation);
            return (Aniversario)aniversarioDynamoDB;
        }
        public async Task<Aniversario> ObterPorIdAsync(string id, CancellationToken cancellation)
        {
            var aniversarioDynamoDB = await _dynamoDBContext.LoadAsync<AniversarioDynamoDB>(id, cancellation);

            var aniversario = (Aniversario)aniversarioDynamoDB;
            return aniversario;
        }
        public async Task<Aniversario> ObterPorSlugAsync(string slug, CancellationToken cancellation)
        {
            List<ScanCondition> conditions = new List<ScanCondition>();
            conditions.Add(new ScanCondition("Slug", ScanOperator.Equal, slug));

            var search = _dynamoDBContext.ScanAsync<AniversarioDynamoDB>(conditions);
            var searchResponse = await search.GetRemainingAsync(cancellation);

            return searchResponse.Select(f => (Aniversario)f).FirstOrDefault();
        }
        public async Task<Foto> RemoverFotoCarrosselAsync(Foto obj, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
        public async Task<Foto> RemoverFotoDestaqueAsync(Foto obj, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
