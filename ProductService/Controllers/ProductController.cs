using ProductService.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
      
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public ProductController()
        {
        }

        [HttpGet("getproductlist")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                return Ok(await _productRepository.GetProductListAsync());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("getProduct/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var response = await _productRepository.GetProductByIdAsync(id);

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("addproduct")]
        public async Task<ActionResult<Product>> AddProductAsync([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (int.Parse(product.ProductPrice) < 0)
            {
                throw new ArgumentOutOfRangeException("product price is less than zero");
            }
            try
            {
                var response = await _productRepository.AddProductAsync(product);
                return CreatedAtAction(nameof(GetProduct),
                 new { id = response.ProductId }, response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error creating new employee record");
            }
        }

        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var productToUpdate = await _productRepository.GetProductByIdAsync(product.ProductId);

                if (productToUpdate == null)
                    return NotFound($"Product  not found");

                var result = await _productRepository.UpdateProductAsync(product);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("deleteProduct/{id}")]
        public async Task<ActionResult<Product>> DeleteProductAsync(int id)
        {
            try
            {
                var productTodelete = await _productRepository.GetProductByIdAsync(id);

                if (productTodelete == null)
                {
                    return NotFound($"Product not found");
                }
                var response = await _productRepository.DeleteProductAsync(id);
                return response;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
              "Error deleting data");
            }
        }
    }
}
