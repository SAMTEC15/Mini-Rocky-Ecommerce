using Microsoft.AspNetCore.Mvc;
using Rocky.Domain;
using Rocky.Persistence;

namespace Rocky.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicationController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Application> objList = _applicationDbContext.Applications;
            return View(objList);
        }

        //GET-CREATE
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Application application)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Applications.Add(application);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        //GET-Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var check = _applicationDbContext.Applications.Find(id);
            if (check == null)
            {
                return NotFound();
            }
            return View(check);
        }

        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Application application)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Applications.Update(application);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        //GET-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var check = _applicationDbContext.Applications.Find(id);
            if (check == null)
            {
                return NotFound();
            }
            return View(check);
        }

        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int? id)
        {
            var check = _applicationDbContext.Applications.Find(id);
            if (check == null)
            {
                return NotFound();
            }
            _applicationDbContext.Applications.Remove(check);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
