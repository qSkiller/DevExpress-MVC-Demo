using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpressDemo.ILogic;
using DevExpressDemo.Models;

namespace DevExpressDemo.Controllers
{
    public class ShapeController : Controller
    {
        // GET: Shape

        private readonly IShapeLogic _shapeLogic;

        public ShapeController(IShapeLogic shapeLogic)
        {
            _shapeLogic = shapeLogic;
        }

        public ActionResult Index()
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new ShapeModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ShapeCreate(ShapeModel shape)
        {
            if (_shapeLogic.GetAll().ToList().Count > 0)
            {
                _shapeLogic.Edit(shape?.ToLogicModel());
            }
            else
            {
                _shapeLogic.Create(shape?.ToLogicModel());
            }

            return View("Index");

            //return RedirectToAction("Index", "Shape");
        }

        
        public JsonResult ShapeGetAll()
        {
            var data = _shapeLogic.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}