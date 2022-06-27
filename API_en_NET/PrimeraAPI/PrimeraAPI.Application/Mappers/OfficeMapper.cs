using PrimeraAPI.BusinessModels.models.Office;
using PrimeraAPI.DataAccess.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAPI.Application.Mappers
{
    public class OfficeMapper
    {
        public static OfficeDto MapToOfficeDtoFromOfficeResponse(OfficeResponse office)
        {
            return new OfficeDto
            {
                OfficeCode = office.OfficeCode,
                City = office.City,
                Country = office.Country,
                Phone = office.Phone,
                AddressLine1 = office.AddressLine1,
                AddressLine2 = office.AddressLine2,
                State = office.State,
                PostalCode = office.PostalCode,
                Territory = office.Territory
            };
        }
        public static OfficeResponse MapToOfficeResponseFromOfficeDto(OfficeDto office)
        {
            return new OfficeResponse
            {
                OfficeCode = office.OfficeCode,
                City = office.City,
                Country = office.Country,
                Phone = office.Phone,
                AddressLine1 = office.AddressLine1,
                AddressLine2 = office.AddressLine2,
                State = office.State,
                PostalCode = office.PostalCode,
                Territory = office.Territory
            };
        }
        public static OfficeDto MapToOfficeDtoFromCreateOfficeRequest(CreateOfficeRequest office)
        {
            return new OfficeDto
            {
                OfficeCode = office.OfficeCode,
                City = office.City,
                Country = office.Country,
                Phone = office.Phone,
                AddressLine1 = office.AddressLine1,
                AddressLine2 = office.AddressLine2,
                State = office.State,
                PostalCode = office.PostalCode,
                Territory = office.Territory
            };
        }
        public static List<OfficeResponse> MapToOfficeResponseListFromOfficeDtoList(List<OfficeDto> products)
        {

            return products.Select(p => MapToOfficeResponseFromOfficeDto(p)).ToList();
        }
    }
}
