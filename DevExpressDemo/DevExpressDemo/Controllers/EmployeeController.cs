using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpressDemo.Data;

namespace DevExpressDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DevExpressDemoContext _db= new DevExpressDemoContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View(_db.Employees.ToList());
        }
    }
}