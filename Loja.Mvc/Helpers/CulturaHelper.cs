using System.Collections.Generic;
using System.Globalization;
using System.Web;

namespace Loja.Mvc.Helpers
{
    public class CulturaHelper
    {
        public const string LinguagemPadrao = "pt-BR";

        public string Abreviacao { get; private set; }
        public CultureInfo CultureInfo { get; private set; }
        public string NomeNativo { get; private set; }
        private List<string> LinguagensSuportadas { get; }
            = new List<string> { LinguagemPadrao, "es", "en-US", "fr" };


        public CulturaHelper()
        {
            ObterRegiao();
        }

        private void ObterRegiao()
        {
            var linguagem = LinguagemPadrao;
            var linguagemSelecionada = HttpContext.Current.Request.Cookies[Cookie.LinguagemSelecionada];

            if (linguagemSelecionada != null && LinguagensSuportadas.Contains(linguagemSelecionada.Value))
            {
                linguagem = linguagemSelecionada.Value;
            }

            var cultura = CultureInfo.CreateSpecificCulture(linguagem);

            CultureInfo = cultura;

            var regiao = new RegionInfo(cultura.LCID);

            NomeNativo = regiao.NativeName;
            Abreviacao = regiao.TwoLetterISORegionName.ToLower();
        }
    }
}