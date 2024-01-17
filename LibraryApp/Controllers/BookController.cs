using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryApp.Presentation.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var bookList=_unitOfWork.BookRepository.GetAll().ToList();
            
            return View(bookList);
        }

        // Get olan IAction metodlar sayfa açılır açılmaz karşımıza gelen sayfayı temsil eder.
        public IActionResult Create() 
        {
            IEnumerable<Category> categories = _unitOfWork.CategoryRepository.GetAll();
            ViewBag.categories = new SelectList(categories, "Id", "CategoryName");

            IEnumerable<Writer> writers= _unitOfWork.WriterRepository.GetAll();
            ViewBag.writers = new SelectList(writers, "Id", "WriterFullName");


        return View();

        }

        // post IAction metodlarında yapılan submit işlemi sonunda karşılayan metodlardır.
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookRepository.Addasync(book);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(Guid id) 
        {

            IEnumerable<Category> categories = _unitOfWork.CategoryRepository.GetAll();
            ViewBag.categories = new SelectList(categories, "Id", "CategoryName");
            IEnumerable<Writer> writers = _unitOfWork.WriterRepository.GetAll();
            ViewBag.writers = new SelectList(writers, "Id", "WriterFullName");

            var model= _unitOfWork.BookRepository.Find(id);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.BookRepository.Update(book);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(Guid id)
        {
            var model=_unitOfWork.BookRepository.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _unitOfWork.BookRepository.Remove(book);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
