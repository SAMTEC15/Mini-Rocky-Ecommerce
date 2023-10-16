﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
