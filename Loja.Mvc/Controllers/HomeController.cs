﻿using Loja.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DefinirLinguagemPadrao();
            return View();
        }

        private void DefinirLinguagemPadrao()
        {
            if (Request.Cookies[Cookie.LinguagemSelecionada] != null)
            {
                return;
            }

            var linguagem = CulturaHelper.LinguagemPadrao;

            if (Request.UserLanguages  != null && Request.UserLanguages[0] != string.Empty)
            {
                linguagem = Request.UserLanguages[0];
            }

            var linguagemSelecionadaCookie = new HttpCookie(Cookie.LinguagemSelecionada, linguagem);
            linguagemSelecionadaCookie.Expires = DateTime.MaxValue;

            Response.Cookies.Add(linguagemSelecionadaCookie);
        }

        public ActionResult DefinirLinguagem(string linguagem)
        {
            Response.Cookies[Cookie.LinguagemSelecionada].Value = linguagem;

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}