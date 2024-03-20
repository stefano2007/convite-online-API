using Xunit;

namespace ConviteOnline.Domain.Tests.Entities
{
    [CollectionDefinition(nameof(GeradorBogusCollection))]
    public class FotoTests
    {
        readonly GeradorBogusFixture _geradorBogusFixture;
        public FotoTests(GeradorBogusFixture geradorBogusFixture)
        {
            _geradorBogusFixture = geradorBogusFixture;
        }

        [Fact(DisplayName = "Criar Foto valida")]
        [Trait("Categoria", "Entidade - Foto")]
        public void NovaFoto_Valida_Sucesso()
        {
            // Arrange
            var foto = _geradorBogusFixture.GerarFotoValida();

            // Act

            // Assert 
        }

        [Fact(DisplayName = "Criar Foto invalida")]
        [Trait("Categoria", "Entidade - Foto")]
        public void NovaFoto_Invalida_Erro()
        {
            // Arrange

            // Act

            // Assert 
        }
    }
}
