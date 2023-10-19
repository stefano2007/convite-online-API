using ConviteOnline.Domain.Entities;

namespace ConviteOnline.Domain.Interfaces
{
    public interface IRespostaRepositorio
    {
        Task<Resposta> ObterPorIdAsync(string id, CancellationToken cancellation);
        Task<IEnumerable<Resposta>> ObterPorAniversarioIdAsync(string aniversarioId, CancellationToken cancellation);
        Task<Resposta> CriarAsync(Resposta obj, CancellationToken cancellation);
        Task<Resposta> AlterarAsync(Resposta obj, CancellationToken cancellation);
        Task<Resposta> DeletaAsync(Resposta obj, CancellationToken cancellation);
    }
}
