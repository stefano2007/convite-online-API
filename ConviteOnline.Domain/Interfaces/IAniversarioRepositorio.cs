using ConviteOnline.Domain.Entities;

namespace ConviteOnline.Domain.Interfaces
{
    public interface IAniversarioRepositorio
    {
        Task<Aniversario> ObterPorIdAsync(int id);
        Task<Aniversario> ObterPorSlugAsync(string slug);
        Task<Aniversario> CriarAsync(Aniversario obj);
        Task<Aniversario> AlterarAsync(Aniversario obj);
        Task<Aniversario> DeletaAsync(Aniversario obj);
        Task<Foto> AdicionarFotoAsync(Foto obj);
        Task<Foto> RemoverFotoAsync(Foto obj);
        Task<Foto> AdicionarFotoDestaqueAsync(Foto obj);
        Task<Foto> RemoverFotoDestaqueAsync(Foto obj);
        Task<Foto> AdicionarFotoCarrosselAsync(Foto obj);
        Task<Foto> RemoverFotoCarrosselAsync(Foto obj);
    }
}
