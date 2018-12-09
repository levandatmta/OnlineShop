using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var dao = new CategoryDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category ca)
        {
            if (ModelState.IsValid)
            {
                if (ca.Status == null) ca.Status = true;
                var dao = new CategoryDao();
                var Result = dao.Create(ca);
                if (Result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed");
                }
            }
            return View(ca);
        }
        public ActionResult Edit(long id)
        {
            var dao = new CategoryDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Category ca)
        {
            if (ModelState.IsValid)
            {
                if (ca.Status == null) ca.Status = true;
                var dao = new CategoryDao();
                var result = dao.Edit(ca);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Fail");
            }
            return View(ca);

        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var dao = new CategoryDao();
            if (dao.Delete(id))
            {
                return Json(new
                {
                    data = true
                });
            }
            else{
                return Json(new
                {
                    data = false
                });
            }
        }
    }
}