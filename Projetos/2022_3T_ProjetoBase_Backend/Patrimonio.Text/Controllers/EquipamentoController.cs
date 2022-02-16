using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace Patrimonio.Text.Controllers
{
    public class EquipamentoController
    {
        [Fact]
        public void DeveListarTodosEquipamentos()
        {
            var listaEquipamentos = new List<Equipamento>();

            var equipamento1 = new Equipamento();
            equipamento1.Id = 1;
            equipamento1.NomePatrimonio = "Impressora";
            equipamento1.Imagem = "teste";
            equipamento1.Descricao = "Imprime colorido e preto e branco.";
            equipamento1.Ativo = true;
            equipamento1.DataCadastro = DateTime.Now;

            listaEquipamentos.Add(equipamento1);

            var fakeRepository = new Mock<IEquipamentoRepository>();
            fakeRepository.Setup(x => x.Listar()).Returns(listaEquipamentos);

            var controller = new EquipamentosController(fakeRepository.Object);

            var resultado = controller.GetEquipamentos();

            Assert.IsType<OkObjectResult>(resultado);

        }

        [Fact]
        public void DeveAtualizarUmEquipamento()
        {

            var equipamento1 = new Equipamento();
            equipamento1.Id = 1;
            equipamento1.NomePatrimonio = "Impressora";
            equipamento1.Imagem = "teste";
            equipamento1.Descricao = "Imprime colorido e preto e branco.";
            equipamento1.Ativo = true;
            equipamento1.DataCadastro = DateTime.Now;

            var fakeRepository = new Mock<IEquipamentoRepository>();
            fakeRepository.Setup(x => x.Alterar(equipamento1));

            var controller = new EquipamentosController(fakeRepository.Object);

            var resultado = controller.PutEquipamento(equipamento1.Id, equipamento1);

            Assert.IsType<NoContentResult>(resultado);

        }
    }
}
