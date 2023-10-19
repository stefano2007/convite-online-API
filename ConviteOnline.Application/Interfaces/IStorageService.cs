using ConviteOnline.Application.DTOs;

namespace ConviteOnline.Application.Interfaces
{
    public interface IStorageService
    {
        Task<string> CarregaArquivoAsync(UploadFileDTO arquivo, string caminho, CancellationToken cancellation);
        Task<bool> DeletarArquivoAsync(string urlFile, CancellationToken cancellation);
        Task CriarCaminhoAsync(string caminho, CancellationToken cancellation);
        Task<bool> ExisteCaminhoAsync(string caminho, CancellationToken cancellation);
        Task<IEnumerable<string>> ListaArquivosAsync(string caminho, CancellationToken cancellation);
    }
}
