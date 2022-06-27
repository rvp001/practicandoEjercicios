using PrimeraAPI.DataAccess.Mappers;
using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Contracts.Repositories;

namespace PrimeraAPI.DataAccess.Repositories
{
    public class ProductLineRepository : IProductLineRepository
    {
        private ApplicationDbContext _context;
        public ProductLineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedDto<ProductLineDto> GetProductLinesPaginated(string description = "", int page = 1, int itemsPerPage = 5)
        {
            PaginatedDto<ProductLineDto> result = new PaginatedDto<ProductLineDto>();

            var query = from p in _context.Productlines
                        where (string.IsNullOrEmpty(description) || (!string.IsNullOrEmpty(p.TextDescription) && p.TextDescription.Contains(description)))
                        select ProductLineMapper.MapToProductLineDtoFromProductLine(p);

            result.Total = query.Count();
            int skip = (page - 1) * itemsPerPage;
            result.Page = page;
            result.ItemsPerPage = itemsPerPage;
            result.Results = query.Skip(skip).Take(itemsPerPage).ToList();

            return result;
        }

        public ProductLineDto? GetProductLineByCode(string productLineCode)
        {
            var query = from p in _context.Productlines
                        where p.ProductLine1 == productLineCode
                        select ProductLineMapper.MapToProductLineDtoFromProductLine(p);

            return query.FirstOrDefault();
        }

        public void DeleteProductLine(ProductLineDto product)
        {
            _context.Productlines.Remove(ProductLineMapper.MapToProductLineFromProductLineDto(product));
        }

        public ProductLineDto AddProductLine(ProductLineDto productLine)
        {
            var productInserted = _context.Productlines.Add(ProductLineMapper.MapToProductLineFromProductLineDto(productLine));

            return ProductLineMapper.MapToProductLineDtoFromProductLine(productInserted.Entity);
        }

        public ProductLineDto UpdateProductLine(ProductLineDto productLine)
        {

            var productUpdated = _context.Productlines.Update(ProductLineMapper.MapToProductLineFromProductLineDto(productLine));

            return ProductLineMapper.MapToProductLineDtoFromProductLine(productUpdated.Entity);

        }

    }
}
