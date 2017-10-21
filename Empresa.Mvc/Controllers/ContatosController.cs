using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Empresa.Repositorio.SqlServer;
using Empresa.Dominio;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Empresa.Mvc.Controllers
{
    public class ContatosController : Controller
    {
        private readonly EmpresaDbContext _contexto;
        private IDataProtector _protectorProvider;

        public ContatosController(EmpresaDbContext contexto, IDataProtectionProvider protectionProvider, IConfiguration configuracao)
        {
            _contexto = contexto;
            //Adicionado método para criptografia de senha
            _protectorProvider = protectionProvider.CreateProtector(configuracao.GetSection("ChaveCriptografia").Value);
        }

        // GET: /Index/
        public IActionResult Index()
        {
            return View(_contexto.Contatos.ToList());
        }

        // GET: /Create/
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Create/
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            //TODO -  Fazer ViewModel
            if (!ModelState.IsValid)
            {
                return View(contato);
            }

            contato.Senha = _protectorProvider.Protect(contato.Senha);
            _contexto.Add(contato);
            _contexto.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
