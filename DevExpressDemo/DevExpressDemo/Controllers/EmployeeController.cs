using System.Web.Mvc;
using DevExpressDemo.ILogic;
using DevExpressDemo.Models;

namespace DevExpressDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        private readonly IEmployeeLogic _employeeLogic;

        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        public ActionResult Index()
        {
            return View(_employeeLogic.GetAll());
        }

        [ValidateInput(false)]
        public ActionResult EmployeePartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("EmployeePartialView", _employeeLogic.GetAll());
        }

        [HttpPost,ValidateInput(false)]
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
    }
}