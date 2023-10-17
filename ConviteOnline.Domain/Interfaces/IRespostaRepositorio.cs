using ConviteOnline.Domain.Entities;

namespace ConviteOnline.Domain.Interfaces
{
    public interface IRespostaRepositorio
    {
        Task<Foto> ObterPorIdAsync(int id);
        Task<IEnumerable<Foto>> ObterPorSlugAsync(string slug);
        Task<Foto> CriarAsync(Foto obj);
        Task<Foto> AlterarAsync(Foto obj);
        Task<Foto> DeletaAsync(Foto obj);
    }
}
