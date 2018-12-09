using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
           /*Chưa bắt các lỗi khi thêm, sửa dữ liệu*/
        /*Chưa có nút bấn để hiển thị ra Slide*/
        // GET: Admin/Slide
        public ActionResult Index()
        {
            var dao = new SlideDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Slide sl)
        {
            var dao = new SlideDao();
            var result = dao.Create(sl);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(sl);
            }
        }
        public ActionResult Edit(long ID)
        {
            var dao = new SlideDao();
            var model = dao.GetById(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Slide sl)
        {
            var dao = new SlideDao();
            var result = dao.Edit(sl);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(sl);
            }
        }
        [HttpPost]
        public ActionResult Delete(long ID)
        {
            var dao = new SlideDao();
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
                    data = true
                });
            }
        }
    }
}