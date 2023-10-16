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
    }
}
