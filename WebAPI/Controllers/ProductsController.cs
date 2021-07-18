using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        private IProductImageService _productImageService;
        public ProductsController(IProductService productService, IProductImageService productImageService) 
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductdetails")]
        public IActionResult GetProductDetails() 
        {
            var result = _productService.GetProductDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product) // client'dan,angular'dan,react'dan vs. gönderdiğin ürünü buraya koy.
        {
            var result = _productService.Add(product);
            if (result.Success)// işlem sonucu true ise
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductdetailsbyid")]
        public IActionResult GetProductDetailsById(int id)
        {
            var result = _productService.GetProductDetailsById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
