using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using LibraryApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryApp.Presentation.Controllers
{
    public class WriterController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public WriterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index()
        {
            var writerList = _unitOfWork.WriterRepository.GetAll().ToList();
            return View(writerList);
        }

        public IActionResult Create()
        {

            

            return View();
        }

        [HttpPost]
        public IActionResult Create(Writer writer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.WriterRepository.Addasync(writer);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Edit(Guid id)
        {
            var model = _unitOfWork.WriterRepository.Find(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Writer writer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.WriterRepository.Update(writer);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(Guid id)
        {
            var model = _unitOfWork.WriterRepository.Find(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Writer writer)
        {

            _unitOfWork.WriterRepository.Remove(writer);
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }

        public IActionResult Details(Guid id) 
        {
            var query=_unitOfWork.WriterRepository.GetWriterDetails(id);

            return View(query);
        }
    }
}
