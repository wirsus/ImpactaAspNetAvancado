using System.Collections.Generic;
using System.Linq;

namespace Loja.Dominio
{
    public class Leilao
    {
        public const decimal DescontoMaximo = 0.1m;
        //https://github.com/JeremySkinner/FluentValidation
        public int Id { get; set; }
        public string NomeLote { get; set; }
        public decimal Preco { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<string> Validar()
        {
            var erros = new List<string>();

            if (string.IsNullOrEmpty(NomeLote?.Trim()))
            {
                erros.Add("O nome do lote é obrigatório");
            }
            
            var somaProdutos = Produtos.Sum(p => p.Preco);

            if (somaProdutos - Preco > somaProdutos * DescontoMaximo)
            {
                erros.Add("O valor do lote está abaixo do permitido.");
            }

            if (Produtos.Count == 0)
            {
                erros.Add("Não existem produtos selecionados para este lote!");
            }

            return erros;
        }
    }
}
