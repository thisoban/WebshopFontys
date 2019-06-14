using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebshopFontys.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            //get info from user
            return View();
        }
        public IActionResult Order()
        {
            //get info from user
            return RedirectToAction("Index","Order");
        }
    }
}