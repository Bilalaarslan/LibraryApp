using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryApp.Presentation.Controllers
{
    public class StudentController : Controller
    {
        internal readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var studentList=_unitOfWork.StudentRepository.GetAll().ToList();
            return View(studentList);
        }

        public IActionResult Create()
        {
            //IEnumerable tipinde classes yaratıp databaseden Repository aracılığıyla tüm classlarımızı çekeceğiz. Daha sonra "ViewBag.classes" özelliğimize SelectList tipinde dönmesi gereken new SelectList(classes, "Id", "StudentName"); yi temel alan ve ClassNamesini içeren verileri ekleriz. Böylece cshtml'imizde yazdırabileceğiz.
            IEnumerable<MyClass> classes = _unitOfWork.MyClassRepository.GetAll();
            ViewBag.classes = new SelectList(classes, "Id", "ClassName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student) 
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StudentRepository.Addasync(student);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            //ViewBag ile çektiğimiz listeleri cshtml e taşıyabiliriz.
            IEnumerable<MyClass> classes = _unitOfWork.MyClassRepository.GetAll();
            ViewBag.classes = new SelectList(classes, "Id", "ClassName");

            //model nesnesi sayesinde id ye ait Myclass nesnesi Return View ile csHtml e gidecektir.
            var model=_unitOfWork.StudentRepository.Find(id);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StudentRepository.Update(student);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(Guid id)
        {
            var model = _unitOfWork.StudentRepository.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _unitOfWork.StudentRepository.Remove(student);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
