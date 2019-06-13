using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataModel;
using LogicLayer;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebshopFontys.Controllers
{
    public class CartController : Controller
    {
        private LogicProduct product;
        public IActionResult Index()
        {
           string cookie = Request.Cookies["CartItems"];
            Dictionary<int, int>  winkelmandje = JsonConvert.DeserializeObject<Dictionary<int,int>>(cookie);
           List<Dataproduct> allproducts = product.Productlist();
           List<Dataproduct> CartProducts = new List<Dataproduct>();
           foreach ((int key , int value) in winkelmandje)
           {
               CartProducts =  allproducts.Where(product => product.Id == key).ToList();
           }
            return View(CartProducts);
        }
       
        public IActionResult CartAdd(int id, int quantity)
        {
            string cookie = Request.Cookies["CartItems"];

            if (cookie != null)
            {
                Dictionary<int, int> artikeldictionary = new Dictionary<int, int>();
                artikeldictionary = JsonConvert.DeserializeObject<Dictionary<int, int>>(cookie);
                artikeldictionary.Add(id,quantity);
                string items = JsonConvert.SerializeObject(artikeldictionary); // Hier zet je de dictionary om in een string
                Response.Cookies.Append("CartItems", items); // Hier voeg je de items toe aan de winkelwagen
                return Redirect("../../product/index");
            }
            Dictionary<int, int> artikel = new Dictionary<int, int>();
            artikel.Add(id,quantity);
            string item = JsonConvert.SerializeObject(artikel);
            Response.Cookies.Append("CartItems", item);
            return Redirect("../../product/index");
        }

        public IActionResult CartRemove()
        {

            return View();
        }
    }
}