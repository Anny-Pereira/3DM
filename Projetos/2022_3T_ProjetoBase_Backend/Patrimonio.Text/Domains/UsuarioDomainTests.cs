using Patrimonio.Domains;
using Xunit;

namespace Patrimonio.Text.Domains
{
    public class UsuarioDomainTests
    {

        [Fact]
        //Descrição
        public void DeveRetornarUsuarioPreenchido()
        {

            //Pré-Condição / Arrange
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@gmail.com";
            usuario.Senha = "1236548997";

            //Procedimento / Act
            bool resultado = true;

            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            //Resultado Esperado / Assert
            Assert.True(resultado);

        }

    }
}
