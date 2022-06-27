using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.Application.Mappers;
using PrimeraAPI.BusinessModels;
using PrimeraAPI.BusinessModels.models;
using PrimeraAPI.BusinessModels.models.Office;
using PrimeraAPI.DataAccess.Contracts;
using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Contracts.Repositories;

namespace PrimeraAPI.Application.Services
{
    public class OfficeService : IOfficeService
    {
        private IOfficeRepository _officeRepository;
        private IUnitOfWork _uOw;
        public OfficeService(IOfficeRepository officeRepository, IUnitOfWork uOw)
        {
            _officeRepository = officeRepository;
            _uOw = uOw;
        }
        
        public PaginatedResponse<OfficeResponse> GetOfficesPaginated(OfficeSearchRequest request)
        {
            PaginatedResponse<OfficeResponse> result = new PaginatedResponse<OfficeResponse>();

            PaginatedDto<OfficeDto> search = _officeRepository.GetOfficePaginated(request.Country, request.Page.Value, request.ItemsPerPage.Value);

            result.Results = OfficeMapper.MapToOfficeResponseListFromOfficeDtoList(search.Results);
            result.Total = search.Total;
            result.Page = search.Page;
            result.ItemsPerPage = search.ItemsPerPage;

            return result;
        }

        public OfficeResponse? GetOfficeByCode (string officeCode)
        {
            OfficeDto? office = _officeRepository.GetOfficeByCode(officeCode);
            if (office != null)
            {
                OfficeResponse result = OfficeMapper.MapToOfficeResponseFromOfficeDto(office);

                return result;
            }
            else
                return null;
        }

        public OfficeResponse? AddOffice(CreateOfficeRequest office)
        {
            OfficeDto? existingOffice = _officeRepository.GetOfficeByCode(office.OfficeCode);

            if (existingOffice == null)
            {
                OfficeDto officeToInserted = OfficeMapper.MapToOfficeDtoFromCreateOfficeRequest(office);

                OfficeDto officeInserted = _officeRepository.AddOffice(officeToInserted);

                _uOw.Commit();

                return OfficeMapper.MapToOfficeResponseFromOfficeDto(officeInserted);
            }
            else
                return null;
        }

        public OfficeResponse? UpdateOffice(string code, UpdateOfficeRequest office)
        {
            OfficeDto? existingOffice = _officeRepository.GetOfficeByCode(code);

            if (existingOffice != null)
            {
                //existingOffice.OfficeCode = code;
                existingOffice.City = office.City;
                existingOffice.Phone = office.Phone;
                existingOffice.AddressLine1 = office.AddressLine1;
                existingOffice.AddressLine2 = office.AddressLine2;
                existingOffice.State = office.State;
                existingOffice.Country = office.Country;
                existingOffice.PostalCode = office.PostalCode;
                existingOffice.Territory = office.Territory;

                OfficeDto OfficeUpdated = _officeRepository.UpdateOffice(existingOffice);

                _uOw.Commit();

                return OfficeMapper.MapToOfficeResponseFromOfficeDto(OfficeUpdated);
            }
            else
                return null;
        }


        public bool DeleteOffice(string productCode)
        {
            OfficeDto? product = _officeRepository.GetOfficeByCode(productCode);

            //TODO RVP: Completar la validacion EMPLOYEES

            if (product != null)
            {
                _officeRepository.DeleteOffice(product);

                _uOw.Commit();

                return true;
            }
            else return false;
        }

        
    }
}
