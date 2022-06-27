using PrimeraAPI.BusinessModels.models;
using PrimeraAPI.BusinessModels.models.Office;

namespace PrimeraAPI.Application.Contracts.Services
{
    public interface IOfficeService
    {
        OfficeResponse? GetOfficeByCode(string officeCode);
        OfficeResponse? AddOffice(CreateOfficeRequest office);
        OfficeResponse? UpdateOffice(string code, UpdateOfficeRequest office);
        PaginatedResponse<OfficeResponse> GetOfficesPaginated(OfficeSearchRequest request);
        bool DeleteOffice(string productCode);

    }
}
