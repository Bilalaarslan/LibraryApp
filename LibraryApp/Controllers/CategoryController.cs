using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using LibraryApp.Entity.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LibraryApp.Presentation.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categoryList=_unitOfWork.CategoryRepository.GetAll().ToList();

            return View(categoryList);
        }

        public IActionResult Create() {
        return View();
        
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Addasync(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
        return View();
        }

        public IActionResult Edit(Guid Id)
        {
            var model = _unitOfWork.CategoryRepository.Find(Id);

                return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            

            return View();
        }

        public IActionResult Delete(Guid Id)
        {
            var model=_unitOfWork.CategoryRepository.Find(Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid Id)

        {
            IEnumerable<CategoryDetailsVM> query =_unitOfWork.CategoryRepository.GetCategoryDetails(Id);
            

            //var model = _unitOfWork.CategoryRepository.Find(Id);
            return View(query);
        }

        
    }
}
