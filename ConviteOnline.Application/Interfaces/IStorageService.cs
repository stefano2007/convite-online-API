using ConviteOnline.Application.DTOs;

namespace ConviteOnline.Application.Interfaces
{
    public interface IStorageService
    {
        Task<string> CarregaArquivoAsync(UploadFileDTO arquivo, string aniversarioId, string subPasta, CancellationToken cancellation);
        Task<bool> DeletarArquivoAsync(string urlFile, CancellationToken cancellation);
        Task<IEnumerable<string>> ListaArquivosAsync(string aniversarioId, string subPasta, CancellationToken cancellation);
    }
}
