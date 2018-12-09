using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SizesController : Controller
    {
        // GET: Admin/Sizes
        /*Nhớ bắt các lỗi khi thêm, sửa*/
        public ActionResult Index()
        {
            var dao = new SizeDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Createx(Size s)
        {
            var dao = new SizeDao();
            if (ModelState.IsValid)
            {
                var result = dao.Create(s);
                if (result > 0) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(long Id)
        {
            var dao = new SizeDao();
            var model = dao.GetById(Id);
            return View(model);
        }
        public ActionResult Editx(Size s)
        {
            var dao = new SizeDao();
            if (ModelState.IsValid)
            {
                var result = dao.Edit(s);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    /*Cần 1 cái thông báo vào đây*/
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var dao = new SizeDao();
            if (dao.Delete(id))
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