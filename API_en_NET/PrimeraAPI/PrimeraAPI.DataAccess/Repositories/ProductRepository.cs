using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Contracts.Repositories;
using PrimeraAPI.DataAccess.Mappers;

namespace PrimeraAPI.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedDto<ProductDto> GetProductsPaginated(string description = "", int page = 1, int itemsPerPage = 5)
        {
            PaginatedDto<ProductDto> result = new PaginatedDto<ProductDto>();

            var query = from p in _context.Products
                        where (string.IsNullOrEmpty(description) || p.ProductDescription.Contains(description))
                        select ProductMapper.MapToProductDtoFromProduct(p);

            result.Total = query.Count();
            int skip = (page - 1) * itemsPerPage;
            result.Page = page;
            result.ItemsPerPage = itemsPerPage;
            result.Results = query.Skip(skip).Take(itemsPerPage).ToList();

            return result;
        }

        public List<ProductDto> GetProductsByProductLine(string productLine)
        {
            var query = from p in _context.Products
                        where p.ProductLine == productLine
                        select ProductMapper.MapToProductDtoFromProduct(p);

            return query.ToList();
        }

        public ProductDto? GetProductByCode(string productCode)
        {
            var query = from p in _context.Products
                        where p.ProductCode == productCode
                        select ProductMapper.MapToProductDtoFromProduct(p);

            return query.FirstOrDefault();
        }

        public void DeleteProduct(ProductDto product)
        {
            _context.Products.Remove(ProductMapper.MapToProductFromProductDto(product));
        }

        public ProductDto AddProduct(ProductDto product)
        {
            var productInserted = _context.Products.Add(ProductMapper.MapToProductFromProductDto(product));

            return ProductMapper.MapToProductDtoFromProduct(productInserted.Entity);
        }

        public ProductDto UpdateProduct(ProductDto product)
        {

            var productUpdated = _context.Products.Update(ProductMapper.MapToProductFromProductDto(product));

            return ProductMapper.MapToProductDtoFromProduct(productUpdated.Entity);

        }
    }
}
