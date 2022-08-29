using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOnBussinessLayer.Contracts;
using ShopOnCommonLayer.Models;
using ShopOnWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterfaceProductManager productManager;

        public HomeController(ILogger<HomeController> logger,InterfaceProductManager productManager)
        {
            _logger = logger;
            this.productManager = productManager;
        }

        public IActionResult Index()
        {
            var products = this.productManager.GetProducts(); 
            return View(products);
        }
        public IActionResult Details(int pid)
        {
            var product = this.productManager.GetProductById(pid);
            return View(product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult SearchProductByName(string searchkey)
        {

            List<Product> products = new List<Product>();
            if(searchkey is not null)
            {
                products = productManager.SearchBykey(searchkey).ToList();
            }
            int prodCount = products.Count();
           // HttpContext.Session.SetInt32("productcnt", prodCount);
            ViewBag.productCount = prodCount;
            return View(products);
        }
        public IActionResult SearchProductByName()
        {
            List<Product> products = new List<Product>();
            return View(products);
        }
    }
}
