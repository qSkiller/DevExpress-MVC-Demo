using System.Web.Mvc;
using Castle.Core.Internal;
using DevExpressDemo.ILogic;
using DevExpressDemo.Models;

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
            return View(new UserModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LogIn(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var result = _userLogic.Login(user?.ToLogicModel());
                if (result.IsNullOrEmpty())
                {
                    ViewBag.ErrMessage = "You user name or password is wrong ! ";
                    return View("Index", user);
                }

                if (user != null) Session["userName"] = user.UserName;
            }

            return RedirectToAction("Index", "Employee");
        }

        public ActionResult LogOff()
        {
            Session["userName"] = null;
            return Redirect("/");
        }
    }
}

public enum HeaderViewRenderMode { Full, Title }