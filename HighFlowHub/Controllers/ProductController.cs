// ==========================================================================================
//
// Copyright © 2023 HighFlowHub
//
// History
// ------------------------------------------------------------------------------------------
// Date         Author          EditDate    EditBy
// ------------------------------------------------------------------------------------------
// 2023.11.1   Loan            2023.12.27    Loan    
// ==========================================================================================
//

using Microsoft.AspNetCore.Mvc;
using HighFlowHub.Models;
using HighFlowHub.Services;
using HighFlowHub.Services.Caches;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisCache.Core;
using ProductEntity = HighFlowHub.Entites.Product;
using ProductModel = HighFlowHub.Models.Product;

namespace HighFlowHub.Controllers
{
    /// <summary>
    ///  Product Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<ProductModel, ProductEntity, ProductServices>
    {
        // private readonly IDistributedCache _redis;
        
        private IRedisCache _caches;
        private IMessageProvider _messageProvider;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="productServices">Product Services</param>
        /// <param name="redisServices">Suppliers Services</param>
        /// <param name="messageProvider"></param>
        public ProductController(
            ProductServices productServices, 
            IDistributedCache redisServices,
            IMessageProvider messageProvider            
        ) : base(
            productServices)
        {
            // _redis = redisServices;
            _messageProvider = messageProvider;
        }

        /// <summary>
        ///  Get all product list
        /// </summary>
        /// <returns>List of Products</returns>
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            try
            {
                // var productsRedis = await _redis.GetStringAsync("product-list");
                var productsRedis = await _caches.GetCache<List<ProductModel>>("product-list");
                if (productsRedis is null)
                {
                    // Get and validate product
                    var productsApi = await GetAsync();
                    var productList = productsApi.ToList();

                    // Set data to cache
                    await _caches.CreateCacheByString("product-list", productList);
                    // await _redis.SetStringAsync("product-list", JsonConvert.SerializeObject(productList));

                    return Ok(productList);
                }

                return Ok(productsRedis);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        /// <summary>
        ///  Update Product
        /// </summary>
        /// <param name="model">Product Model</param>
        /// <returns>Updated Product</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product model)
        {
            try
            {
                // Validate model
                // ...

                // Update Model
                var updatedProduct = await base.UpdateAsync(model);
                var productsApi = await GetAsync();

                // Update in Redis
                await _caches.CreateCacheByString(
                    CacheList.ProductList,
                    JsonConvert.SerializeObject(productsApi.ToList())
                );
                // await _redis.SetStringAsync(
                //     CacheList.ProductList,
                //     JsonConvert.SerializeObject(productsApi.ToList())
                // );

                return Ok(updatedProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Create product
        /// </summary>
        /// <param name="model">Product Model</param>
        /// <returns>New Product</returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product model)
        {
            try
            {
                // validate
                // ...

                // Create new product
                var createdProduct = await CreateAsync(model);
                
                // Store new product
                var productsApi = await GetAsync();
                await _caches.CreateCacheByString(
                    CacheList.ProductList,
                    productsApi.ToList()
                );
                _messageProvider.SendMessage(createdProduct);
                
                return Ok(createdProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Delete Product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>True if deleted</returns>
        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            // Delete product
            var result = await base.DeleteAsync(id);
            if (result)
            {
                // Redis Remove item in Product list
                var productsRedis = await _caches.GetCache<List<ProductModel>>(CacheList.ProductList);
                if (productsRedis == null)
                {
                    return false;
                }
                productsRedis.Remove(productsRedis.FirstOrDefault(e => e.Id.Equals(id)));

                // Update item
                await _caches.CreateCacheByString(
                    CacheList.ProductList,
                    productsRedis
                );
            }
            return result;
        }
    }
}