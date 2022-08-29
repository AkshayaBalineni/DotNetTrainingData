using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnBussinessLayer.Contracts;
using ShopOnCommonLayer.Models;
using ShopOnWebApp.Models;
using ShopOnWebApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopOnWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager orderManager;
        public OrderController(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }
        [Authorize]
        public IActionResult PlaceOrder()
        {
            var cartItems = HttpContext.Session.GetSession<List<CartViewModel>>("CartData");
            if (cartItems.Count() == 0)
            {
                return RedirectToAction("DisplayCart", "Cart");
            } 
            var userName = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var customerId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            double totalAmount = 0;
            var order = new Order()
            {
                AspCustomerId = customerId,
                OrderStatus = "New",
                OrderDate = DateTime.UtcNow,
                TotalAmount = totalAmount
            };
            foreach (var item in cartItems)
            {
                order.AddOrderItem (new OrderItem()
                {
                    PId = item.PId,
                    ProductQty = item.Qty,
                    Product = new Product()
                    {
                        PId = item.PId,
                        ProductName = item.ProductName,
                        ImageUrl = item.ImageUrl,
                        ProductPrice=item.Price
                    }
                });
                totalAmount += item.Amount;
            }
            order.TotalAmount = totalAmount;  
            this.orderManager.AddOrder(order);
            ClearSession();
            return View(order);
        }

        private void ClearSession()
        {
            HttpContext.Session.Clear();
        }
    }
}
