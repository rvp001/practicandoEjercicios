using PrimeraAPI.DataAccess.Contracts.Models;

namespace PrimeraAPI.DataAccess.Contracts.Repositories
{
    public interface IOfficeRepository
    {
        OfficeDto? GetOfficeByCode(string officeCode);
        OfficeDto AddOffice(OfficeDto office);
        OfficeDto UpdateOffice(OfficeDto office);
        void DeleteOffice(OfficeDto office);
        PaginatedDto<OfficeDto> GetOfficePaginated(string country = "", int page = 1, int itemsPerPage = 5);
    }
}
