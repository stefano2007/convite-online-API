using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Interfaces;
using ConviteOnline.Application.Utils;
using Microsoft.Extensions.Configuration;

namespace ConviteOnline.Application.Services
{
    public class StorageService : IStorageService
    {
        private readonly AmazonS3ClientUtil _s3ClientUtil;
        public string CaminhoImagens { get; init; }
        public StorageService(AmazonS3ClientUtil s3ClientUtil, IConfiguration configuration)
        {
            _s3ClientUtil = s3ClientUtil;
            CaminhoImagens = configuration["aws.s3.caminho.imagens"];
        }
        
        public async Task<string> CarregaArquivoAsync(UploadFileDTO arquivo, string aniversarioId, string subPasta, CancellationToken cancellation)
        {
            var caminhoArquivo = Path.Combine(CaminhoImagens, aniversarioId, subPasta);

            var s3Response = await _s3ClientUtil.UploadFileAsync(arquivo, caminhoArquivo, cancellation);

            return s3Response.UrlResult;
        }

        public async Task<bool> DeletarArquivoAsync(string urlFile, CancellationToken cancellation)
        {
            var s3Response = await _s3ClientUtil.DeleteFileAsync(urlFile, cancellation);

            return s3Response.StatusCode == 200;
        }

        public async Task<IEnumerable<string>> ListaArquivosAsync(string aniversarioId, string subPasta, CancellationToken cancellation)
        {
            var caminhoArquivo = Path.Combine(CaminhoImagens, aniversarioId, subPasta);

            var lista = await _s3ClientUtil.ListObjectsAsync(_s3ClientUtil.BucketNameStorage, caminhoArquivo, cancellation);

            return lista.S3Objects.Select(x => x.Key);
        }
    }
}
