using ConviteOnline.Application.DTOs;

namespace ConviteOnline.Application.Interfaces
{
    public interface IFotoService
    {
        Task<FotoDTO> ObterPorIdAsync(string id, CancellationToken cancellation);
        Task<IEnumerable<FotoDTO>> ObterPorAniversarioIdAsync(string aniversarioId, CancellationToken cancellation);
        Task<FotoDTO> CriarAsync(FotoCriarDTO obj, UploadFileDTO file, CancellationToken cancellation);
        Task<FotoDTO> AlterarAsync(FotoAlterarDTO obj, CancellationToken cancellation);
        Task<FotoDTO> DeletaAsync(string id, CancellationToken cancellation);
    }
}
