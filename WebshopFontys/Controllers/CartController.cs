using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
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
        public IActionResult Cart(LogicProduct test)
        {//need fix quanity add and description add to show on cart
           string cookie = Request.Cookies["CartItems"];
           Dictionary<int, int>  winkelmandje = JsonConvert.DeserializeObject<Dictionary<int,int>>(cookie);
           List<Dataproduct> allproducts = test.Productlist().ToList();
           List<Dataproduct> CartProducts = new List<Dataproduct>();
           foreach ((int key , int value) in winkelmandje)
           {
               CartProducts = allproducts.Where(product => product.Id == key).ToList(); 
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
                return Redirect("../../product/products");
            }
            Dictionary<int, int> artikel = new Dictionary<int, int>();
            artikel.Add(id,quantity);
            string item = JsonConvert.SerializeObject(artikel);
            Response.Cookies.Append("CartItems", item);
            return Redirect("../../product/Products");
        }

        public IActionResult CartRemove(Dataproduct Cartproduct)
        {
            string cookie = Request.Cookies["CartItems"];
            Dictionary<int, int> artikeldictionary = new Dictionary<int, int>();
            artikeldictionary = JsonConvert.DeserializeObject<Dictionary<int, int>>(cookie);
            artikeldictionary.Remove(Cartproduct.Id + Cartproduct.Quantity);
            return Redirect("../../cart/cart");
        }
    }
}