
using System;
using Patrimonio.Domains;
using Xunit;

namespace Patrimonio.Text.Domains
{
    public class EquipamentoDomainTests
    {
        [Fact]
        public void DeveRetornarUmEquipamentoPreenchido()
        {

            //Pré-Condição / Arrange
            Equipamento equipamento = new Equipamento();
            equipamento.Imagem = "";
            equipamento.Descricao = "abc";
            equipamento.Ativo = false;
            equipamento.DataCadastro = new DateTime(2021-09-12);
            equipamento.NomePatrimonio = "";

            //Procedimento / Act
            bool resultado = true;

            if (equipamento.Imagem == null || equipamento.NomePatrimonio == null)
            {
                resultado = false;
            }

            //Resultado Esperado / Assert
            Assert.True(resultado);

        }

    }
}
