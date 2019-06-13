using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebshopFontys.Controllers
{
    
    public class OrderController : Controller
    {
        private LogicOrder Lgorder;
        public IActionResult Index(DataOrder orders)
        {

            return View(Lgorder.GetOrders());
        }

        public IActionResult SingleOrder(DataOrder dataOrder)
        {
            return View();
        }
    }
}