using ConviteOnline.Application.DTOs;

namespace ConviteOnline.Application.Interfaces
{
    public interface IRespostaService
    {
        Task<RespostaDTO> ObterPorIdAsync(string id, CancellationToken cancellation);
        Task<IEnumerable<RespostaDTO>> ObterPorAniversarioIdAsync(string aniversarioId, CancellationToken cancellation);
        Task<RespostaDTO> CriarAsync(RespostaCriarDTO obj, CancellationToken cancellation);
        Task<RespostaDTO> AlterarAsync(RespostaAlterarDTO obj, CancellationToken cancellation);
        Task<RespostaDTO> DeletaAsync(string id, CancellationToken cancellation);
    }
}
