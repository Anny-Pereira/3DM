using Moq;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Xunit;

namespace Patrimonio.Text.Controllers
{
    public class EquipamentoController
    {
        [Fact]
        public void DeveListarTodosEquipamentos()
        {
            var fakeRepository = new Mock<IEquipamentoRepository>();


        }
    }
}
