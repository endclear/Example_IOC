using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Core.Entity;
using Core.IService;
using FX.Core;
using QuanLyHangHoa.Models;

namespace QuanLyHangHoa.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logon() {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(UserModel user) {
            IUser _user = IoC.Resolve<IUser>();
            if (_user.GetUser(user.Username, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.Username, user.Rememberme);
                return RedirectToAction("Index", "Home");
            }
            else {
                ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không chính xác");
            }
            return View(user);
            
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Logon", "Account");
        }

    }
}
