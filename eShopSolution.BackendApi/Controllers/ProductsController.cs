﻿using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eShopSolution.ViewModels.Catalog.ProductImages;
using Microsoft.AspNetCore.Authorization;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //http://localhost:port/products?pageIndex-1&pageSize=10&CategoryId=
        [HttpGet("{languageId}")]
        // 1. request lấy từ From query
        //2. return Ok trả về status 200
        /*public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var product = await _productService.GetAllByCategoryId(languageId, request);
            return Ok(product);
        }*/
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var product = await _productService.GetAllPaging(request);
            return Ok(product);
        }

        //http://localhost:port/product/1
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(product);
        }

        [HttpPost]
        [Consumes("multipart/form-data")] // cho phép nhận kểu dữ liệu truyền lên là 1 form-data
        // 1. request lấy từ From body do là httpPost
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
            {
                return BadRequest(); // trả về lỗi 400
            }

            var product = await _productService.GetById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _productService.Delete(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")] //HttpPatch : Update một phần bảng ghi
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccessful = await _productService.UpdatePrice(productId, newPrice);
            if (isSuccessful)
            {
                return Ok();
            }

            return BadRequest();
        }

        //Images
        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
            {
                return BadRequest();
            }

            return Ok(image);
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imageId = await _productService.AddImage(productId, request);
            if (imageId == 0)
            {
                return BadRequest();
            }

            var image = await _productService.GetImageById(imageId);
            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.UpdateImage(imageId, request);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}