using Microsoft.AspNetCore.Mvc;
using Rocky.Domain;
using Rocky.Persistence;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _applicationDbContext.Categories;
            return View(objList);
        }

        //GET-CREATE
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _applicationDbContext.Categories.Add(category);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //GET-Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {                
                return NotFound();                
            }

            var check = _applicationDbContext.Categories.Find(id);
            if (check == null)
            {
                return NotFound();
            }
            return View(check);
        }

        //GET-check
        /*public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {                
                return NotFound();
            }

            var check = _applicationDbContext.Categories.Find(id);
            if (check == null)
            {
                return NotFound();
            }
            _applicationDbContext.Categories.Remove(check);
            var dele = _applicationDbContext.SaveChanges();
            return View(dele);
        }*/
    }
}
