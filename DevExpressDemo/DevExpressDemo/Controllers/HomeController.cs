using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpressDemo.Data;
using DevExpressDemo.Data.Models;
using DevExpressDemo.ILogic;
using DevExpressDemo.Logic;
using DevExpressDemo.Models;

namespace DevExpressDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DevExpressDemoContext _db = new DevExpressDemoContext();
        //private readonly IEmployeeLogic _employeeLogic;

        //public HomeController(IEmployeeLogic employeeLogic)
        //{
        //    _employeeLogic = employeeLogic;
        //}

        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            //var result = _employeeLogic.GetAll();
            return View(_db.Employees.ToList());
            //return View(NorthwindDataProvider.GetCustomers());
        }
        
        public ActionResult GridViewPartialView() 
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", _db.Employees.ToList());
            //return PartialView("GridViewPartialView", NorthwindDataProvider.GetCustomers());
        }
    
    }
}

public enum HeaderViewRenderMode { Full, Title }