using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Universidade.Data;
using Universidade.Models;
using Universidade.ViewModels;

namespace Universidade.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly EscolaContexto _context;


        public HomeController(EscolaContexto context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<DataMatriculaGrupo> dados = from estudante in _context.Estudantes
                                                   group estudante by estudante.DataMatricula into dateGroup
                                                   select new DataMatriculaGrupo()
                                                   {
                                                       DataMatricula = dateGroup.Key,
                                                       EstudanteContador = dateGroup.Count()
                                                   };

            return View(await dados.AsNoTracking().ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}