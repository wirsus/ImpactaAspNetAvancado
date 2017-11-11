﻿using Lojas.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Areas.Vendas.Models
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Categorias = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "ProdutoCabecalhoNome", ResourceType = typeof(Resource))]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? Preco { get; set; }

        [Required]
        public Nullable<int> Estoque { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        public List<SelectListItem> Categorias { get; set; }

        public HttpPostedFileBase Imagem { get; set; }

        [Display(Name = "Em leilão")]
        public bool EmLeilao { get; set; }
    }
}