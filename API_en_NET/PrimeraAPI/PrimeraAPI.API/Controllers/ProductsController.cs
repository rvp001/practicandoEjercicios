using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.BusinessModels.models;
using PrimeraAPI.BusinessModels.models.Product;
using System.ComponentModel.DataAnnotations;

namespace PrimeraAPI.API.Controllers
{
    //api/products
    //(las mayusculas da igual)
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //api/products/paginated
        [HttpPost]
        [Route("paginated")]
        [ProducesResponseType(typeof(PaginatedResponse<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProductsPaginated(ProductSearchRequest request)
        {
            var products = _productService.GetProductsPaginated(request);

            return Ok(products);
        }

        //api/products/{code}
        [HttpGet]
        [Route("{code}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProductByCode([Required][MaxLength(15)] string code)
        {
            ProductResponse? product = _productService.GetProductByCode(code);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NoContent();
            }
        }

        //api/products/{code}
        [HttpDelete]
        [Route("{code}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProduct([Required][MaxLength(15)] string code)
        {
            bool result = _productService.DeleteProduct(code);

            if (result)
                return NoContent();
            else
                return NotFound("El producto no existe");
        }

        //api/products
        [HttpPost]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddProduct(CreateProductRequest request)
        {
            ProductResponse? product = _productService.AddProduct(request);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return Conflict("El producto ya existe");
            }
        }

        //api/products/{code}
        [HttpPut]
        [Route("{code}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProduct([Required][MaxLength(15)] string code, UpdateProductRequest request)
        {
            ProductResponse? product = _productService.UpdateProduct(code, request);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound("El producto no existe");
            }
        }
    }
}
