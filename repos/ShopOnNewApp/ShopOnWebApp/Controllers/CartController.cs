using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnBussinessLayer.Contracts;
using ShopOnWebApp.Models;
using ShopOnWebApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly InterfaceProductManager productManager;

        public CartController(InterfaceProductManager productManager)
        {
            this.productManager = productManager;
        }
        public IActionResult AddToCart(int pid)
        {
            var product = productManager.GetProductById(pid);
            // CartViewModel cartVM = null;
            if (product != null)
            {
                var cartVM = new CartViewModel()
                {
                    PId = product.PId,
                    ProductName = product.ProductName,
                    Price = product.ProductPrice,
                    ImageUrl = product.ImageUrl,
                    Qty = 1,
                    Amount = product.ProductPrice * 1

                };
                var cartVMs = HttpContext.Session.GetSession<List<CartViewModel>>("CartData");
                
                if (cartVMs == null)
                 {
                     cartVMs = new List<CartViewModel>();
                    cartVMs.Add(cartVM);
                }
                 else
                 {
                    bool isfound = false;
                     foreach (var item in cartVMs.ToList())
                     { 
                         if (item.PId == cartVM.PId)
                        {
                            if(item.Qty >= 5)
                            {
                                item.Qty = 5;
                                isfound = true;
                            }
                            else
                            {
                                item.Qty += 1;
                                item.Amount = item.Qty * item.Price;
                                isfound = true;
                            }
                            break;
                        } 
                     }
                     if(!isfound)
                    {
                        cartVMs.Add(cartVM);
                    }   
                 }
                int cartcnt = cartVMs.Count;
                HttpContext.Session.SetSession("CartData", cartVMs);
                HttpContext.Session.SetInt32("CartCount", cartcnt);
                ViewBag.cartCount = cartcnt;
            }
           // TempData["cart"] = JsonConvert.SerializeObject(cartVM);
            return RedirectToAction("DisplayCart");
        }
        public IActionResult DisplayCart()
        {
            var cartVMs = HttpContext.Session.GetSession<List<CartViewModel>>("CartData");
            int cartcnt = 0;
            if(cartVMs != null)
            {
                cartcnt = cartVMs.Count;
            }
            HttpContext.Session.SetInt32("CartCount", cartcnt);
            ViewBag.cartCount = cartcnt;
            // var cartVM = JsonConvert.DeserializeObject<CartViewModel>(TempData["cart"].ToString());
            return View(cartVMs);
        }
        public IActionResult DeleteProductFromCart(int id)
        {
            var cartVMs = HttpContext.Session.GetSession<List<CartViewModel>>("CartData");
            foreach(var cartVM in cartVMs.ToList())
            {
                if (cartVM.PId == id)
                    cartVMs.Remove(cartVM);
            }
            HttpContext.Session.SetSession("CartData", cartVMs);
            int cartcnt = cartVMs.Count;
            HttpContext.Session.SetInt32("CartCount", cartcnt);
            ViewBag.cartCount = cartcnt;
            // var newcartVMs = HttpContext.Session.GetSession<List<CartViewModel>>("CartData");
            return RedirectToAction("DisplayCart");
        }
        public IActionResult RestoringData(int pid,int qty,double amount)
        {
            var cartVMs = HttpContext.Session.GetSession<List<CartViewModel>>("CartData");
            foreach (var cartVM in cartVMs.ToList())
            {
                if (cartVM.PId == pid)
                {
                    cartVM.Qty = qty;
                    cartVM.Amount = amount;
                    break;
                }
                    
            }
            HttpContext.Session.SetSession("CartData", cartVMs);
            // var newcartVMs = HttpContext.Session.GetSession<List<CartViewModel>>("CartData");
            return RedirectToAction("DisplayCart");
        }
    }
}
