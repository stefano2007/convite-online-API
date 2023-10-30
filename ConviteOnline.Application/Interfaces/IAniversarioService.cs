using ConviteOnline.Application.DTOs;

namespace ConviteOnline.Application.Interfaces
{
    public interface IAniversarioService
    {
        Task<AniversarioDTO> ObterPorIdAsync(string id, CancellationToken cancellation);
        Task<AniversarioDTO> ObterPorSlugAsync(string slug, CancellationToken cancellation);
        Task<AniversarioDTO> CriarAsync(AniversarioCriarDTO obj, CancellationToken cancellation);
        Task<AniversarioDTO> AlterarAsync(AniversarioAlterarDTO obj, CancellationToken cancellation);
        Task<AniversarioDTO> DeletaAsync(string id, CancellationToken cancellation);
        Task<FotoDTO> AdicionarFotoDestaqueAsync(FotoCriarDTO obj, UploadFileDTO file, CancellationToken cancellation);
        Task<FotoDTO> RemoverFotoDestaqueAsync(string id, string aniversarioId, CancellationToken cancellation);
        Task<FotoDTO> AdicionarFotoCarrosselAsync(FotoCriarDTO obj, UploadFileDTO file,  CancellationToken cancellation);
        Task<FotoDTO> RemoverFotoCarrosselAsync(string id, string aniversarioId, CancellationToken cancellation);
        Task<AniversarioDTO> AlterarImagemConviteAsync(string id, UploadFileDTO file, CancellationToken cancellation);
        Task<AniversarioDTO> RemoverImagemConviteAsync(string id, CancellationToken cancellation);
    }
}
