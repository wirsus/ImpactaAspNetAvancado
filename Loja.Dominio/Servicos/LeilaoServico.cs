using Loja.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Servicos
{
    public class LeilaoServico
    {
        private ILeilaoRepositorio _repositorio;

        public LeilaoServico(ILeilaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
