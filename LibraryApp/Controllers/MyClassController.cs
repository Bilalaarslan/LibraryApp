using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Entity;
using LibraryApp.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Presentation.Controllers
{
    public class MyClassController : Controller
    {

        private readonly IUnitOfWork _unitOfWorks;
        //Interfacelerden nesne yaratılamaz ama referans noktası olabilir.
        public MyClassController(IUnitOfWork unitOfWork)
        {
            _unitOfWorks = unitOfWork;
        }
        public IActionResult Index()
        {
            var myclassList = _unitOfWorks.MyClassRepository.GetAll().ToList();
            return View(myclassList);
        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Create(MyClass myClass)
        {
            // Kullanıcı tarafından yapılan girişi myClass karşılar ve _unitOfWorks.MyClassRepository ile Add matedu içinde myClass vererek data base imize gönreririz, sonrasında _unitOfWorks içerisindeki save metodu ile database kaydını yaparız. Sonrasında RedirectToAction ile ("Index")'e sayfatı açması için komut veririz.
            if (ModelState.IsValid)
            {
                _unitOfWorks.MyClassRepository.Addasync(myClass);
                _unitOfWorks.Save();
                return RedirectToAction("Index");

            }
            return View();

        }

        public IActionResult Edit(Guid Id)
        {
            var model = _unitOfWorks.MyClassRepository.Find(Id);


            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(MyClass myClass)
        {
            if (ModelState.IsValid)
            {
                _unitOfWorks.MyClassRepository.Update(myClass);
                _unitOfWorks.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(Guid Id)
        {
            var model=_unitOfWorks.MyClassRepository.Find(Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(MyClass myClass)
        {
            _unitOfWorks.MyClassRepository.Remove(myClass);
            _unitOfWorks.Save();
            return RedirectToAction("Index");

        }

    }

}
