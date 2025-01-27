using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("ProductsByTypeId/{id}")]
        public async Task<IActionResult> GetProductsByTypeIdAsync(int id)
        {
            if (id <= 0 || id > 3)
            {
                return BadRequest("The product type ID must be greater than zero.");
            }

            try
            {
                var products = await _productService.GetProductsByTypeId(id);

                if (products == null || !products.Any())
                {
                    return NotFound("No products found for the given type ID.");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}