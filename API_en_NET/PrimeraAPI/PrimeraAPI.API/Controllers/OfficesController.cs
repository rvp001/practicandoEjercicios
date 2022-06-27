using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.BusinessModels.models;
using PrimeraAPI.BusinessModels.models.Office;
using System.ComponentModel.DataAnnotations;

namespace PrimeraAPI.API.Controllers
{
    //api/offices
    //(las mayusculas da igual)
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : Controller
    {
        private IOfficeService _officeService;
        public OfficesController(IOfficeService officeService)
        {
            _officeService = officeService;
        }


        //api/products/{officeCode}
        [HttpGet]
        [Route("{officeCode}")]
        [ProducesResponseType(typeof(OfficeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOfficeByCode([Required][MaxLength(10)]string officeCode)
        {
            OfficeResponse? office = _officeService.GetOfficeByCode(officeCode);
            if (office != null)
            {
                return Ok(office);
            }
            else
                return NoContent();
        }


        //api/offices/paginated
        [HttpPost]
        [Route("paginated")]
        [ProducesResponseType(typeof(PaginatedResponse<OfficeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOfficesPaginated(OfficeSearchRequest request)
        {
            var offices = _officeService.GetOfficesPaginated(request);

            return Ok(offices);
        }

        //api/offices/{officeCode}
        [HttpDelete]
        [Route("{officeCode}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProduct([Required][MaxLength(10)] string officeCode)
        {
            bool result = _officeService.DeleteOffice(officeCode);

            if (result)
                return NoContent();
            else
                return NotFound("El office no existe");
        }


        //api/offices
        [HttpPost]
        [ProducesResponseType(typeof(OfficeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddOffice(CreateOfficeRequest request)
        {
            OfficeResponse? product = _officeService.AddOffice(request);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return Conflict("El office ya existe");
            }
        }

        //api/offices/{officeCode}
        [HttpPut]
        [Route("{officeCode}")]
        [ProducesResponseType(typeof(OfficeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateOffice([Required][MaxLength(10)] string officeCode, UpdateOfficeRequest request)
        {
            OfficeResponse? office = _officeService.UpdateOffice(officeCode, request);

            if (office != null)
            {
                return Ok(office);
            }
            else
            {
                return NotFound("El office no existe");
            }
        }



    }
}
