

using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using Xunit;

namespace Patrimonio.Text.Controllers
{
    public class LoginControllerTests
    {

        [Fact]
        public void DeveRetornarUmUsuarioInvalido()
        {
            //Pré-Condição
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "tsuka@email.com";
            loginViewModel.Senha = "123456789";

            var controller = new LoginController(fakeRepository.Object);


            //Procedimento
            var resultado = controller.Login(loginViewModel);

            //Resultado Esperado
            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }

        [Fact]
        public void DeveRetornarUmUsuarioValido()
        {
            //Pré-Condição
            var usuarioFake = new Usuario();
            usuarioFake.Email = "paulo@email.com";
            usuarioFake.Senha = "$2a$11$eiw46XgULrlCodbrlouINuq8rwTp2FYueccX2P7PFcTf47I90hjvG";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuarioFake);

            LoginViewModel loginViewModel = new LoginViewModel();

            var controller = new LoginController(fakeRepository.Object);


            //Procedimento
            var resultado = controller.Login(loginViewModel);

            //Resultado Esperado
            Assert.IsType<OkObjectResult>(resultado);

        }

    }
}
