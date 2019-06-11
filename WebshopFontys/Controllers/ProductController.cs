 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using LogicLayer;
 using Microsoft.AspNetCore.Mvc;

namespace WebshopFontys.Controllers
{
    public class ProductController : Controller
    {
        private LogicLayer.LogicProduct logic = new LogicProduct();
        public IActionResult Index()
        {
            return View(logic.Productlist());
        }
        public IActionResult ProductAdd()
        {
            return View();
        }
    }
}