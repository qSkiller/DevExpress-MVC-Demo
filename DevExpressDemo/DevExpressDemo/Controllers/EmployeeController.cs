using System;
using System.Linq;
using System.Web.Mvc;
using DevExpressDemo.ILogic;
using DevExpressDemo.Models;

namespace DevExpressDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        private readonly IEmployeeLogic _employeeLogic;
        private readonly IDepartmentLogic _departmentLogic;

        public EmployeeController(IEmployeeLogic employeeLogic, IDepartmentLogic departmentLogic)
        {
            _employeeLogic = employeeLogic;
            _departmentLogic = departmentLogic;
        }

        public ActionResult Index()
        {
            //if (Session["userName"] == null)
            //{
            //    return RedirectToAction("Index","Home");
            //}
            //var result = _employeeLogic.GetAll() ? _employeeLogic.GetAll() : "";
            return View(_employeeLogic.GetAll());
        }

        [ValidateInput(false)]
        public ActionResult EmployeePartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("EmployeePartialView", _employeeLogic.GetAll());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EmployeePartialCreate(EmployeeModel employee)
        {
            //if (!ModelState.IsValid)
            //{

            //}

            if (employee != null)
            {
                _employeeLogic.Create(employee.ToLogicModel());
            }

            return RedirectToAction("Index", "Employee");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EmployeePartialDelete(int employeeId)
        {
            if (employeeId > 0)
            {
                _employeeLogic.Delete(employeeId);
            }

            return RedirectToAction("Index", "Employee");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EmployeePartialUpdate(EmployeeModel employee)
        {
            if (employee != null)
            {
                _employeeLogic.Edit(employee.ToLogicModel());
            }

            return RedirectToAction("Index", "Employee");
        }


        public ActionResult EmployeeCreate()
        {
            return View(new EmployeeViewModel
            {
                EmployeeModel = new EmployeeModel
                {
                    DepId = 1
                },
                DepartmentModels = _departmentLogic.GetAll().Select(x => x.ToViewModel())
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EmployeeCreate(EmployeeViewModel employeeView)
        {

            _employeeLogic.Create(employeeView.EmployeeModel?.ToLogicModel());

            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public ActionResult EmployeeEdit(int employeeId)
        {
            var editEmployee = _employeeLogic.Get(employeeId)?.ToViewModel();

            if (editEmployee == null)
            {
                editEmployee = new EmployeeModel { EmployeeId = -1 };
            }

            ViewBag.Message = "Your application description page1111.";

            return View(editEmployee);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EmployeeEdit(EmployeeModel employee)
        {


            return RedirectToAction("Index", "Employee");
        }
    }
}