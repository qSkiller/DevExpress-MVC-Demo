using System.Web.Mvc;
using Castle.Core.Internal;
using DevExpress.Web.Mvc;
using DevExpressDemo.ILogic;
using DevExpressDemo.Models;

namespace DevExpressDemo.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        private readonly IUserLogic _userLogic;

        public RegisterController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var result = _userLogic.Create(user?.ToLogicModel());
                if (!result.IsNullOrEmpty())
                {
                    ViewBag.ErrMessage = result;

                    return View("Index",user);
                }
            }

            return RedirectToAction("Index", "Home");
        }
        
    }
}