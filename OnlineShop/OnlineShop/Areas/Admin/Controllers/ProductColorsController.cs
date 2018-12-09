using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductColorsController : Controller
    {
        // GET: Admin/ProductColors
        public ActionResult Index()
        {
            var dao = new ProductColorDao();
            var model = dao.ListAll();
            setViewBagProduct();
            setViewBagColor();
            return View(model);
        }
        public ActionResult Create()
        {
            setViewBagProduct();
            setViewBagColor();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductColor pc)
        {
            var dao = new ProductColorDao();
            if (ModelState.IsValid)
            {
                var result = dao.Create(pc);
                if (result != null) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View(pc);
        }
        public ActionResult Edit(long ProductID, long ColorID)
        {
            var dao = new ProductColorDao();
            var model = dao.GetById(ProductID, ColorID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductColor pc)
        {
            var dao = new ProductColorDao();
            if (ModelState.IsValid)
            {
                var result = dao.Edit(pc);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công");
                }
            }
            return View(pc);
        }
        [HttpPost]
        /*Chưa thực hiện được do chưa biết truyền dữ liệu 2 biến vào trong ajax*/
        public ActionResult Delete(long ProductID, long ColorID)
        {
            var dao = new ProductColorDao();
            if (dao.Delete(ProductID, ColorID))
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
        public void setViewBagColor(long? ColorID = null)
        {
            var dao = new ColorDao();
            ViewBag.ColorID = new SelectList(dao.ListAll(), "ID", "Name", ColorID);
        }
    }
}