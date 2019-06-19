using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1;

namespace WebshopFontys.Controllers
{
    public class UserController : Controller
    {
        public IActionResult rolecheck(int rol)
        { 
            string role;
           
            role = rol.ToString();
            
            Response.Cookies.Append("role", role);
            return Redirect("../home");
        }
    }
}