﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using DataModel;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebshopFontys.Controllers
{
    
    public class OrderController : Controller
    {
        private LogicOrder Lgorder = new LogicOrder();
        public IActionResult orders(DataOrder orders)
        {

            return View(Lgorder.GetOrders());
        }

        public IActionResult SingleOrder(DataOrder dataOrder)
        {
            //zien van een order met klant en alles
            return View();
        }

        public IActionResult MakeOrder(Dataproduct dataProduct, DataOrder dataOrder)
        {

            return RedirectToPage("orders");
        }
    }
}