using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.BusinessModels.models;
using PrimeraAPI.BusinessModels.models.Productline;
using System.ComponentModel.DataAnnotations;

namespace PrimeraAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLinesController : Controller
    {
        private IProductLineService _productLineService;

        public ProductLinesController(IProductLineService productLineService)
        {
            _productLineService = productLineService;
        }

        //api/productlines/paginated
        [HttpPost]
        [Route("paginated")]
        [ProducesResponseType(typeof(PaginatedResponse<ProductLineResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProductLinesPaginated(ProductLineSearchRequest request)
        {
            var products = _productLineService.GetProductLinesPaginated(request);

            return Ok(products);
        }

        //api/productlines/{code}
        [HttpGet]
        [Route("{code}")]
        [ProducesResponseType(typeof(ProductLineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProductLineByCode([Required][MaxLength(50)] string code)
        {
            ProductLineResponse? product = _productLineService.GetProductByCode(code);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NoContent();
            }
        }

        //api/productlines/{code}
        [HttpDelete]
        [Route("{code}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProductLine([Required][MaxLength(50)] string code)
        {
            BaseResponse<bool> result = _productLineService.DeleteProductLine(code);

            if (result.Results)
                return NoContent();
            else
                return NotFound(result.Error);
        }

        //api/productlines
        [HttpPost]
        [ProducesResponseType(typeof(ProductLineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddProductLine(CreateProductLineRequest request)
        {
            ProductLineResponse? product = _productLineService.AddProductLine(request);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return Conflict("La linea de producto ya existe");
            }
        }

        //api/productlines/{code}
        [HttpPut]
        [Route("{code}")]
        [ProducesResponseType(typeof(ProductLineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProduct([Required][MaxLength(15)] string code, UpdateProductLineRequest request)
        {
            ProductLineResponse? product = _productLineService.UpdateProductLine(code, request);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound("La linea de producto no existe");
            }
        }
    }
}
