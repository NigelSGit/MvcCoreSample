using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MvcCoreSample.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        // Constructor injection example: 'pieRepository' and 'categoryRepository' are injected into the controller using the service registration in Program.cs
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";
            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "All pies");
            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
