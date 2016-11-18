using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpressDemo.ILogic;

namespace DevExpressDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            //return View(NorthwindDataProvider.GetCustomers());
            return View();
        }

    }
}

public enum HeaderViewRenderMode { Full, Title }