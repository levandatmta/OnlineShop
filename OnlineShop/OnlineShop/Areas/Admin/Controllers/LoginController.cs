using Model.DAO;
using Model.EF;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Registerx(Account ac)
        {
            var dao = new AccountDao();
            if (ModelState.IsValid)
            {
                var id = dao.Create(ac);
                if (id > 0)
                {
                    return RedirectToAction("Index", "AdLogIn");
                }
                else
                {
                    ModelState.AddModelError("", "Mo Access");
                }
            }
            return RedirectToAction("Index", "LogIn");
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                var result = dao.Login(model.Username, model.Password);
                if (result == 1)
                {
                    var user = dao.GetByUsername(model.Username);
                    var userSession = new UserLogin();
                    userSession.Username = user.Username;
                    userSession.AccountID = user.ID;
                    userSession.Name = user.Name;
                    userSession.Image = user.Image;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "HomeAd");
                }
                else
                {
                    if (result == 0) ModelState.AddModelError("", "Tài khoản không tồn tại");
                    else
                    {
                        if (result == -1) ModelState.AddModelError("", "Tài khoản hiện đang bị khóa");
                        else ModelState.AddModelError("", "Mật khẩu không đúng");
                    }

                }
            }
            return View("Index");
        }
    }
}