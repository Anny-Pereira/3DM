using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.Text.Utils
{
    public class CriptografiaTests
    {

        [Fact]
        public void DeveRetornarHashEmBCrypt()
        {

            //Pré-Condição
            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$\d[a-z]\$\d\d\$.{53}");

            //Procedimento
            var retorno = regex.IsMatch(senha);

            //Resultado Esperado
            Assert.True(retorno);

        }

        [Fact]
        public void DeveRetornarComparacaoValida()
        {

            //Pré-Condição
            var senha = "Teste12345";
            var hash = "$2a$11$3PeN4OffeSEhfjdcSE457O5ejs5UeDUPKQDtQVJWSYHRePdj8ca5.";

            //Procedimento
            var comparacao = Criptografia.Comparar(senha, hash);

            //Resultado Esperado
            Assert.True(comparacao);

        }

    }
}
