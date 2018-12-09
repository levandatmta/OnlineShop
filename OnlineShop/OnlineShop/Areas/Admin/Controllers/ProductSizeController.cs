using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductSizeController : Controller
    {
        // GET: Admin/ProductSize
        public ActionResult Index()
        {
            var dao = new ProductSizeDao();
            var model = dao.ListAll();
            setViewBagProduct();
            setViewBagSize();
            return View(model);
        }
        public ActionResult Create()
        {
            setViewBagProduct();
            setViewBagSize();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductSize s)
        {
            var dao = new ProductSizeDao();
            if (ModelState.IsValid)
            {
                var result = dao.Create(s);
                if (result != null) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View(s);
        }
        public ActionResult Edit(long ProductID,long sizeID)
        {
            var dao = new ProductSizeDao();
            var model = dao.GetById(ProductID,sizeID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductSize s)
        {
            var dao = new ProductSizeDao();
            if (ModelState.IsValid)
            {
                var result = dao.Edit(s);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View(s);
        }
        [HttpDelete]
        public ActionResult Delete(long ProductID,long SizeID)
        {
            var dao = new ProductSizeDao();
            if (dao.Delete(ProductID, SizeID))
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
        public void setViewBagProduct(long? ProductID = null)
        {
            var dao = new ProductDao();
            ViewBag.ProductID = new SelectList(dao.ListAllCn(), "ID", "Name", ProductID);
        }
        public void setViewBagSize(long? SizeID = null)
        {
            var dao = new SizeDao();
            ViewBag.SizeID = new SelectList(dao.ListAll(), "ID", "Size1", SizeID);
        }
    }
}