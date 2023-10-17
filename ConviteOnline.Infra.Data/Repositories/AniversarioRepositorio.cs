using ConviteOnline.Domain.Entities;
using ConviteOnline.Domain.Interfaces;

namespace ConviteOnline.Infra.Data.Repositories
{
    public class AniversarioRepositorio : IAniversarioRepositorio
    {
        public Task<Foto> AdicionarFotoAsync(Foto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Foto> AdicionarFotoCarrosselAsync(Foto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Foto> AdicionarFotoDestaqueAsync(Foto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Aniversario> AlterarAsync(Aniversario obj)
        {
            throw new NotImplementedException();
        }

        public Task<Aniversario> CriarAsync(Aniversario obj)
        {
            throw new NotImplementedException();
        }

        public Task<Aniversario> DeletaAsync(Aniversario obj)
        {
            throw new NotImplementedException();
        }

        public Task<Aniversario> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Aniversario> ObterPorSlugAsync(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<Foto> RemoverFotoAsync(Foto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Foto> RemoverFotoCarrosselAsync(Foto obj)
        {
            throw new NotImplementedException();
        }

        public Task<Foto> RemoverFotoDestaqueAsync(Foto obj)
        {
            throw new NotImplementedException();
        }
    }
}
