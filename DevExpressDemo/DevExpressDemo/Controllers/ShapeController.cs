using System.Linq;
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
            var result = _shapeLogic.GetAll().ToList().Count;

            if (result == 0)
            {
                _shapeLogic.Create(shape?.ToLogicModel());
            }

            return View("Index");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ShapeEdit(ShapeModel shape)
        {
            _shapeLogic.Edit(shape?.ToLogicModel());

            return View("Index");
        }


        public JsonResult ShapeGetAll()
        {
            var data = _shapeLogic.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}