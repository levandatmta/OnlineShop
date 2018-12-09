using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProducerController : Controller
    {
        // GET: Admin/Producer
        public ActionResult Index()
        {
            var dao = new ProducerDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Producer pr)
        {
            var dao = new ProducerDao();
            if (ModelState.IsValid)
            {
                if (pr.Status == null) pr.Status = true;
                var result = dao.Create(pr);
                if (result > 0) return RedirectToAction("Index", "Producer");
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View(pr);
        }
        public ActionResult Edit(long Id)
        {
            var dao = new ProducerDao();
            var model = dao.GetById(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Producer pr)
        {
            var dao = new ProducerDao();
            if (ModelState.IsValid)
            {
                if (pr.Status == null) pr.Status = true;
                var result = dao.Edit(pr);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View(pr);
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var dao = new ProducerDao();
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