using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ColorsController : Controller
    {
        // GET: Admin/Colors
        public ActionResult Index()
        {
            var dao = new ColorDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Color cl)
        {
            var dao = new ColorDao();
            if (ModelState.IsValid)
            {
                var result = dao.Create(cl);
                if (result > 0) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View(cl);
        }
        public ActionResult Edit(long ID)
        {
            var dao = new ColorDao();
            var model = dao.GetById(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Color cl)
        {
            var dao = new ColorDao();
            if (ModelState.IsValid)
            {
                var result = dao.Edit(cl);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    /*Cần 1 thông báo khi đi vào đây*/
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View(cl);
        }
        [HttpPost]
        public ActionResult Delete(long ID)
        {
            var dao = new ColorDao();
            if (dao.Delete(ID))
            {
                return Json(new
                {
                    data = true
                });
            }
            else
            {
                return Json(new
                {
                    data = false
                });
            }
        }
    }
}