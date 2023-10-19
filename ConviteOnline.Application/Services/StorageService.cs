using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Interfaces;
using ConviteOnline.Application.Utils;

namespace ConviteOnline.Application.Services
{
    public class StorageService : IStorageService
    {
        private readonly AmazonS3ClientUtil _s3ClientUtil;
        public StorageService(AmazonS3ClientUtil s3ClientUtil)
        {
            _s3ClientUtil = s3ClientUtil;
        }

        public async Task<string> CarregaArquivoAsync(UploadFileDTO arquivo, string caminho, CancellationToken cancellation)
        {
            var s3Response = await _s3ClientUtil.UploadFileAsync(arquivo, caminho, cancellation);

            return s3Response.UrlResult;
        }

        public Task CriarCaminhoAsync(string caminho, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletarArquivoAsync(string urlFile, CancellationToken cancellation)
        {
            var s3Response = await _s3ClientUtil.DeleteFileAsync(urlFile, cancellation);

            return s3Response.StatusCode == 200;
        }

        public Task<bool> ExisteCaminhoAsync(string caminho, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> ListaArquivosAsync(string caminho, CancellationToken cancellation)
        {
            var lista = await _s3ClientUtil.ListObjectsAsync(_s3ClientUtil.BucketNameStorage, caminho, cancellation);

            return lista.S3Objects.Select(x => x.Key);
        }
    }
}
