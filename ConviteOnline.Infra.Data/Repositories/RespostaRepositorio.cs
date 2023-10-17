using ConviteOnline.Domain.Entities;
using ConviteOnline.Domain.Interfaces;

namespace ConviteOnline.Infra.Data.Repositories
{
    public class RespostaRepositorio : IRespostaRepositorio
    {
        public Task<Foto> AlterarAsync(Foto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Foto> CriarAsync(Foto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Foto> DeletaAsync(Foto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Foto> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Foto>> ObterPorSlugAsync(string slug)
        {
            throw new NotImplementedException();
        }
    }
}
