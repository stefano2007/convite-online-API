using ConviteOnline.Domain.Entities;

namespace ConviteOnline.Domain.Interfaces
{
    public interface IFotoRepositorio
    {
        Task<Foto> ObterPorIdAsync(string id, CancellationToken cancellation);
        Task<IEnumerable<Foto>> ObterPorAniversarioIdAsync(string aniversarioId, CancellationToken cancellation);
        Task<Foto> CriarAsync(Foto obj, CancellationToken cancellation);
        Task<Foto> AlterarAsync(Foto obj, CancellationToken cancellation);
        Task<Foto> DeletaAsync(Foto obj, CancellationToken cancellation);
    }
}
