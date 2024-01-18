using Employee.DataAccess.Repository.IRepository;
using Employee.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Employees> empList = _unitOfWork.Employee.GetALL();
            return View(empList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employees emp)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Employee.Add(emp);
                _unitOfWork.Save();
            }
            TempData["success"] = "Successfully Employee Create";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            else
            {
                Employees emp = _unitOfWork.Employee.Get(u => u.Id == id);

                if (emp == null)
                {
                    return NotFound();
                }

                return View(emp);
            }
        }

        [HttpPost]
        public IActionResult Update(Employees emp)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Update(emp);
                _unitOfWork.Save();
            }
            TempData["success"] = "Successfully Employee Update";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
