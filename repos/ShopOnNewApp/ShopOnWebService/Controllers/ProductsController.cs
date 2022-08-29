using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnBussinessLayer.Contracts;
using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAsyncManager productManager;
        public ProductsController(IProductAsyncManager productManager)
        {
            this.productManager = productManager;
        }
        /// <summary>
        /// Returns All Products
        /// </summary>
        /// <returns> Returns All Products</returns>
        /// <remarks>
        /// 
        ///     Sample Request : GET: /api/products
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var products = await productManager.GetProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occured while Retriving products!");
            }
        }
        /// <summary>
        /// Returns Product By Id
        /// </summary>
        /// <returns>Returns Product By Id</returns>
        /// <remarks>
        /// 
        ///     Sample Request : GET: /api/products/id
        /// </remarks>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var product = await productManager.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occured while Retriving product!");
            }
        }
        /// <summary>
        /// Creates a Product
        /// </summary>
        /// <returns>Creates a Product</returns>
        /// <remarks>
        /// 
        ///     Sample Request : CREATE: /api/products
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                var result = await this.productManager.AddProduct(product);
                return CreatedAtAction(nameof(Get), new { id = result.PId }, result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occured while Inserting product!");
            }
        }
        /// <summary>
        /// Updates a Product
        /// </summary>
        /// <returns>Updates a Product</returns>
        /// <remarks>
        /// 
        ///     Sample Request : PUT: /api/products/id
        /// </remarks>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> Update(int id, Product product)
        {
            try
            {
                if (product == null || id != product.PId || product.PId == 0 || product.ProductPrice == 0)
                {
                    return BadRequest();
                }
                var result = await this.productManager.UpdateProduct(product);
                if(result == null)
                {
                    return NotFound($"Product with {id} not found");
                }
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occured while Updating product!");
            }
        }
        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <returns>Deletes a Product</returns>
        /// <remarks>
        /// 
        ///     Sample Request : DELETE: /api/products/id
        /// </remarks>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var product = await productManager.GetProductById(id);
                if (product == null)
                {
                    return NotFound($"Product with {id} not found");
                }
                await this.productManager.DeleteProduct(id);
                return Ok($"Product with {id} Deleted");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occured while Deleting product!");
            }
        }
        
    }
}
