using System.Web.Mvc;
using DevExpressDemo.ILogic;
using DevExpressDemo.Models;
using DevExpress.Web.Mvc;

namespace DevExpressDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserLogic _userLogic;

        public HomeController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            //return View(NorthwindDataProvider.GetCustomers());
            return View(new UserModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LogIn(string userName,string password)
        {
            ViewBag["message"] = _userLogic.Login(userName,password);

            return RedirectToAction("Index", ViewBag["message"] == null ? "Employee" : "Home");
        }

        [HttpPost,ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        public ActionResult Register()
        {
            return View(new UserModel());
        }

        [HttpPost, ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(UserModel user)
        {
            //&& CaptchaExtension.GetIsValid("captcha")
            if (ModelState.IsValid)
            {
                ViewBag.SuccessValidation = true;
                
            }

            ViewBag["message"] = _userLogic.Create(user?.ToLogicModel());
            return RedirectToAction(ViewBag["message"] == null ? "Index" : "Register", "Home");
        }

    }
}

public enum HeaderViewRenderMode { Full, Title }