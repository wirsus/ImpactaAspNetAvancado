using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Tests
{
    [TestClass()]
    public class LeilaoTests
    {
        [TestMethod()]
        public void ValidarSucessoTest()
        {
            // Arrange - Montar o objeto a ser testado
            var leilao = new Leilao();
            leilao.Id = 1;
            leilao.NomeLote = "Leilao Sucesso";
            leilao.Preco = 90;
            leilao.Produtos = new List<Produto> { new Produto { Preco = 100} };

            // Act - Testar de fato
            var erros = leilao.Validar();

            // Assert - Afirmar ou comparações dos resultados
            Assert.IsTrue(erros.Count == 0);
        }

        [TestMethod()]
        public void ValidarErroTest()
        {

            // Arrange - Montar o objeto a ser testado
            var leilao = new Leilao();
            leilao.Id = 1;
            leilao.NomeLote = "Leilao Sucesso";
            leilao.Preco = 89.9m;
            leilao.Produtos = new List<Produto> { new Produto { Preco = 100 } };

            // Act - Testar de fato
            var erros = leilao.Validar();

            // Assert - Afirmar ou comparações dos resultados
            Assert.IsTrue(erros.Contains("O valor do lote está abaixo do permitido."));
        }
    }
}