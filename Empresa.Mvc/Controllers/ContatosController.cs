using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Empresa.Repositorio.SqlServer;
using Empresa.Dominio;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Empresa.Mvc.Controllers
{
    public class ContatosController : Controller
    {
        private readonly EmpresaDbContext _contexto;
        public ContatosController(EmpresaDbContext contexto)
        {
            _contexto = contexto;
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
        }


    }
}
