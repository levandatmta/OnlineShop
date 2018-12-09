using Model.EF;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OnlineShop.Common;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccountManagementController : BaseController
    {
        /*Có 1 lỗi là khi sửa, xóa xong không show lại ra màn hình mà chỉ update trong cơ sở dữ liệu*/
        // GET: Admin/AccountManagement

        public ActionResult Index()
        {
            var dao = new AccountDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Account ac)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                var Result = dao.Create(ac);
                if (Result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed");
                }
            }
            return View(ac);
        }
        public ActionResult Edit(long ID)
        {
            var dao = new AccountDao();
            var model = dao.GetById(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Account ac)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                var result = dao.Update(ac);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View(ac);
        }
        [HttpPost]
        public JsonResult Delete(long id)
        {
            var dao = new AccountDao();
            var flag = new AccountDao().GetById(id);
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (flag.ID == session.AccountID)
            {
                /*Cần 1 cái thông báo khi chạy vào đây?*/
                /*Thông báo: "Tài khoản hiện đang được sử dụng"*/
                return Json(new
                {
                    data = false
                });
            }
            else
            {
                var result = dao.Delete(id);
                return Json(new
                {
                    data = result
                });
                //return Redirect("/AccountManagerment/Index");
            }
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var flag = new AccountDao().GetById(id);
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (flag.ID == session.AccountID)
            {
                /*Làm sao để có thể hiện ra thông báo khi đi vào đây*/
                return Json(new {
                    status = 2
                });
            }
            else
            {
                var result = new AccountDao().ChangeStatus(id);
                return Json(new
                {
                    status = result
                });
            }

        }
    }
}