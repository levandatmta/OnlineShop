using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        /*Kiểm tra lỗi về ckfinder*/
        /*Xem xét trường topHot*/
        // GET: Admin/Product
        public ActionResult Index()
        {
            var dao = new ProductDao();
            var model = dao.ListAll();
            setViewBag();
            setViewBagproducer();
            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult Create()
        {
            setViewBag();
            setViewBagproducer();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product p)
        {
            var dao = new ProductDao();
            var result = dao.Create(p);
            if(result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
        [ValidateInput(false)]
        public ActionResult Edit(long Id)
        {
            var dao = new ProductDao();
            var model = dao.GetById(Id);
            setViewBag(Id);
            setViewBagproducer(Id);
            return View(model);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            var dao = new ProductDao();
            var result = dao.Edit(p);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var dao = new ProductDao();
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
        public void setViewBag(long? CategoryId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryId = new SelectList(dao.ListAllCn(), "ID", "Name", CategoryId);
        }
        public void setViewBagproducer(long? ProducerId = null)
        {
            var dao = new ProducerDao();
            ViewBag.ProducerId = new SelectList(dao.ListAll(), "ID", "Name", ProducerId);
        }
    }
}