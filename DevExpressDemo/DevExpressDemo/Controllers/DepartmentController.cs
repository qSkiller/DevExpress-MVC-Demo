using System;
using System.Web.Mvc;
using DevExpressDemo.ILogic;
using DevExpressDemo.Models;

namespace DevExpressDemo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department

        private readonly IDepartmentLogic _departmentLogic;

        public DepartmentController(IDepartmentLogic departmentLogic)
        {
            _departmentLogic = departmentLogic;
        }

        public ActionResult Index()
        {
            //if (Session["userName"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            return View(_departmentLogic.GetAll());
        }


        [ValidateInput(false)]
        public ActionResult DepartmentPartialView()
        {
            return PartialView("DepartmentPartialView", _departmentLogic.GetAll());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DepartmentPartialCreate(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentLogic.Create(model?.ToLogicModel());
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return RedirectToAction("Index", "Department");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DepartmentPartialDelete(int depId)
        {
            var model = new object[0];
            if (depId >= 0)
            {
                try
                {
                    _departmentLogic.Delete(depId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            return RedirectToAction("Index", "Department");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DepartmentPartialEdit(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentLogic.Edit(model?.ToLogicModel());
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return RedirectToAction("Index", "Department");
        }
    }
}