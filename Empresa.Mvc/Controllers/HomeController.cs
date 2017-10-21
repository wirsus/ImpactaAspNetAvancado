using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Empresa.Mvc.ViewModels;
using Empresa.Repositorio.SqlServer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;

namespace Empresa.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpresaDbContext _contexto;
        private IDataProtector _protectorProvider;

        public HomeController(EmpresaDbContext contexto, IDataProtectionProvider protectionProvider, IConfiguration configuracao)
        {
            _contexto = contexto;
            //Adicionado método para criptografia de senha
            _protectorProvider = protectionProvider.CreateProtector(configuracao.GetSection("ChaveCriptografia").Value);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                
                return View(viewModel);
            }

            var contato = _contexto.Contatos.Where(c => c.Email == viewModel.Email && _protectorProvider.Unprotect(c.Senha) == viewModel.Senha);
            
            //Verificar se funciona a inversão de proteção ou dados do banco ou dados da tela
            //var contato = _contexto.Contatos.Where(c => c.Email == viewModel.Email && c.Senha == _protectorProvider.Unprotect(viewModel.Senha));

            return View();
        }
    }
}
