using Bogus;
using ConviteOnline.Domain.Entities;
using Xunit;

namespace ConviteOnline.Domain.Tests
{
    [CollectionDefinition(nameof(GeradorBogusCollection))]
    public class GeradorBogusCollection : ICollectionFixture<GeradorBogusFixture>
    { }
    public class GeradorBogusFixture : IDisposable
    {
        private const string regiao = "pt-BR";
        public IEnumerable<Foto> GerarFotosValida(int quantidade = 1)
        {
            var fotosValida = new Faker<Foto>(regiao)
                                    .CustomInstantiator(f =>
                                        new Foto(id: Guid.NewGuid().ToString(), 
                                                aniversarioId: Guid.NewGuid().ToString(), 
                                                src: f.Image.LoremPixelUrl(), 
                                                titulo: f.Lorem.Text(), 
                                                subTitulo: f.Lorem.Text(), 
                                                ordem: 0)
                                    );

            return fotosValida.Generate(quantidade);
        }

        public Foto GerarFotoValida()
        {
            return GerarFotosValida(1).FirstOrDefault();
        }
        public void Dispose()
        {
        }
    }
}
