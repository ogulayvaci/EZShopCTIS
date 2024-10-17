using BLL.DAL;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            var list = _categoryService.Query().ToList();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            // var category = _categoryService.Query().FirstOrDefault(c => c.Record.id == id);
            var category = _categoryService.Query().SingleOrDefault(c => c.Record.id == id);

            if (category == null)
                return NotFound();
            
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Create(category.Record);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            return View(category);
        }
    }
}
