using PrimeraAPI.BusinessModels.models.Office;
using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Contracts.Repositories;
using PrimeraAPI.DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAPI.DataAccess.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private ApplicationDbContext _context;
        public OfficeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedDto<OfficeDto> GetOfficePaginated(string country = "", int page = 1, int itemsPerPage = 5)
        {
            PaginatedDto<OfficeDto> result = new PaginatedDto<OfficeDto>();

            var query = from p in _context.Offices
                        where (string.IsNullOrEmpty(country) || (!string.IsNullOrEmpty(p.Country) && p.Country.Contains(country)))
                        select OfficeMapper.MapToOfficeDtoFromOffice(p);

            result.Total = query.Count();
            int skip = (page - 1) * itemsPerPage;
            result.Page = page;
            result.ItemsPerPage = itemsPerPage;
            result.Results = query.Skip(skip).Take(itemsPerPage).ToList();

            return result;
        }

        public OfficeDto? GetOfficeByCode (string officeCode)
        {
            var query = from o in _context.Offices
                        where o.OfficeCode == officeCode
                        select OfficeMapper.MapToOfficeDtoFromOffice(o);
            return query.FirstOrDefault();
        }

        public OfficeDto AddOffice (OfficeDto office)
        {
            var officeInserted = _context.Offices.Add(OfficeMapper.MapToOfficeFromOfficeDto(office));

            return OfficeMapper.MapToOfficeDtoFromOffice(officeInserted.Entity);

        }

        public OfficeDto UpdateOffice(OfficeDto office)
        {
            var officeUpdated = _context.Offices.Update(OfficeMapper.MapToOfficeFromOfficeDto(office));

            return OfficeMapper.MapToOfficeDtoFromOffice(officeUpdated.Entity);
        }

        public void DeleteOffice(OfficeDto office)
        {
            _context.Offices.Remove(OfficeMapper.MapToOfficeFromOfficeDto(office));

        }
        
        
    }
}
