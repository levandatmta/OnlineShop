using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductClController : Controller
    {
        // GET: ProductCl
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var dao = new CategoryDao();
            var model = dao.ListAllCn();
            return PartialView(model);
        }
    }
}