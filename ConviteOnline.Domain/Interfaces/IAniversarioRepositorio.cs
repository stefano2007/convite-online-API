using ConviteOnline.Domain.Entities;

namespace ConviteOnline.Domain.Interfaces
{
    public interface IAniversarioRepositorio
    {
        Task<Aniversario> ObterPorIdAsync(string id, CancellationToken cancellation);
        Task<Aniversario> ObterPorSlugAsync(string slug, CancellationToken cancellation);
        Task<Aniversario> CriarAsync(Aniversario obj, CancellationToken cancellation);
        Task<Aniversario> AlterarAsync(Aniversario obj, CancellationToken cancellation);
        Task<Aniversario> DeletaAsync(Aniversario obj, CancellationToken cancellation);
        Task<Foto> AdicionarFotoDestaqueAsync(Foto obj, CancellationToken cancellation);
        Task<Foto> RemoverFotoDestaqueAsync(Foto obj, CancellationToken cancellation);
        Task<Foto> AdicionarFotoCarrosselAsync(Foto obj, CancellationToken cancellation);
        Task<Foto> RemoverFotoCarrosselAsync(Foto obj, CancellationToken cancellation);
    }
}
