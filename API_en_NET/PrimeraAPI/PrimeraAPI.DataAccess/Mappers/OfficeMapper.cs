using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Entities;

namespace PrimeraAPI.DataAccess.Mappers
{
    public static class OfficeMapper
    {
        public static OfficeDto MapToOfficeDtoFromOffice (Office office)
        {
            return new OfficeDto
            {
                OfficeCode= office.OfficeCode,
                City= office.City,
                Country= office.Country,
                Phone= office.Phone,
                AddressLine1= office.AddressLine1,
                AddressLine2= office.AddressLine2,
                State= office.State,
                PostalCode= office.PostalCode,
                Territory= office.Territory
            };
        }
        public static Office MapToOfficeFromOfficeDto(OfficeDto office)
        {
            return new Office
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

    }
}
