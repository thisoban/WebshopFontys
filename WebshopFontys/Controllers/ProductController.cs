 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using DataModel;
 using LogicLayer;
 using Microsoft.AspNetCore.Mvc;

namespace WebshopFontys.Controllers
{
    public class ProductController : Controller
    {
        private LogicLayer.LogicProduct logic = new LogicProduct();
        public IActionResult Products()
        {
            if (logic.Productlist() == null)
            {
                return View();
            }

            return View(logic.Productlist());
        }
        public IActionResult ProductAdd()
        {
            return View();
        }
       [HttpPost]
        public IActionResult ProductAdd(Dataproduct ProductNew)
        {
            logic.productadd(ProductNew);
            return  RedirectToAction("Products");
        }
     
        public IActionResult ProductDelete(int id)
        {
            logic.ProductDelete(id);
            return RedirectToAction("Products");
        }

        public IActionResult Test()
        {
            return View(logic.Productlist());
        }
    }
}