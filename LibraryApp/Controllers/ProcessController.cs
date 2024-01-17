using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace LibraryApp.Presentation.Controllers
{
    public class ProcessController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProcessController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var processList=_unitOfWork.ProcessRepository.GetAll().ToList();
            return View(processList);
        }

        public IActionResult Create()
        {
            IEnumerable<Book> books = _unitOfWork.BookRepository.GetAll();
            ViewBag.books = new SelectList(books, "Id", "BookName");

            IEnumerable<Student> students = _unitOfWork.StudentRepository.GetAll();
            ViewBag.students = new SelectList(students, "Id", "StudentName");


            return View();
        }
        [HttpPost]
        public IActionResult Create(Process myprocess)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProcessRepository.Addasync(myprocess);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}
