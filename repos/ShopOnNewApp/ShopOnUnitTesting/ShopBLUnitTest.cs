using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopOnBussinessLayer.Contracts;
using ShopOnBussinessLayer.Implementation;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ShopOnUnitTesting
{
    [TestClass]
    public class ShopBLUnitTest
    {
        private InterfaceProductManager productManager = null;
        private Mock<InterfaceProductRepository> productRepoMock = null;

        [TestInitialize]
        public void Init()
        {
            productRepoMock = new Mock<InterfaceProductRepository>();
            productManager = new ProductManager(productRepoMock.Object);
        }

        [TestMethod]
        public void GetProductsTest()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    PId = 1,
                    ProductName = "Apple I-Pad Mini",
                    ProductPrice = 45609,
                },
                new Product()
                {
                    PId = 2,
                    ProductName = "Apple 5s",
                    ProductPrice = 65679,
                },
                new Product()
                {
                    PId = 3,
                    ProductName = "Apple 10s",
                    ProductPrice = 121699,
                },
                new Product()
                {
                    PId = 4,
                    ProductName = "Apple 8s plus",
                    ProductPrice = 87699,
                }
            };
           productRepoMock.Setup(x => x.GetProducts(false)).Returns(products);
            var expected = new Product()
            {
                PId = 1,
                ProductName = "Apple I-Pad Mini",
                ProductPrice = 45609
            };
            var actual = productManager.GetProducts().FirstOrDefault();
            //1. The actual should not be null
            Assert.IsNotNull(actual);
            //2. The actual's id should be equal to expected's id
            Assert.AreEqual(expected.PId, actual.PId);
            //3. The actual's name should be equal to expected's id
            Assert.AreEqual(expected.ProductName, actual.ProductName);
        }

        [TestMethod]
        public void GetProductByValidIdTest()
        {
            int id = 5;
            Product product = new Product() { PId = 5, ProductName = "iphone 10s pro", ProductPrice = 124000 };
            productRepoMock.Setup(x => x.GetProductById(id)).Returns(product);
            var expected = new Product() { PId = 5, ProductName = "iphone 10s pro", ProductPrice = 124000 };
            var actual = productManager.GetProductById(id);
            //1. The actual should not be null
            Assert.IsNotNull(actual);
            //2. The actual's id should be equal to expected's id
            Assert.AreEqual(expected.PId, actual.PId);
            //3. The actual's name should be equal to expected's id
            Assert.AreEqual(expected.ProductName, actual.ProductName);
        }
        [TestMethod]
        public void GetProductByInValidIdTest()
        {
            int id = 20;
            Product product = null;
            productRepoMock.Setup(x => x.GetProductById(id)).Returns(product);
            var actual = productManager.GetProductById(id);
            //1. The actual should be null
              Assert.IsNull(actual);
        }
        [TestMethod]
        public void GetProductsSortById()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    PId = 1,
                    ProductName = "Apple I-Pad Mini",
                    ProductPrice = 45609,
                },
                new Product()
                {
                    PId = 2,
                    ProductName = "Apple 5s",
                    ProductPrice = 65679,
                },
                new Product()
                {
                    PId = 3,
                    ProductName = "Apple 10s",
                    ProductPrice = 121699,
                },
                new Product()
                {
                    PId = 4,
                    ProductName = "Apple 8s plus",
                    ProductPrice = 87699,
                }
            };
            productRepoMock.Setup(x => x.GetProducts(false)).Returns(products);
            var expected = new Product()
            {
                PId = 1,
                ProductName = "Apple I-Pad Mini",
                ProductPrice = 45609
            };
            var actual = productManager.SortById().FirstOrDefault();
            //1. The actual should not be null
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void DeleteValidProductTest()
        {
            bool value = true;
            var product = new Product() { PId = 4, ProductName = "apple-mini", ProductPrice = 30000 };
            productRepoMock.Setup(x => x.DeleteProduct(product)).Returns(value);
            bool actual = productManager.DeleteProduct(product);
            //1. actual should be true.
            Assert.IsTrue(actual);
        }

    }
}
