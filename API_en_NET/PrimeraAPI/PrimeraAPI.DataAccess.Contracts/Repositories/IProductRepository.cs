using PrimeraAPI.DataAccess.Contracts.Models;

namespace PrimeraAPI.DataAccess.Contracts.Repositories
{
    public interface IProductRepository
    {
        PaginatedDto<ProductDto> GetProductsPaginated(string description = "", int page = 1, int itemsPerPage = 5);
        ProductDto? GetProductByCode(string productCode);
        List<ProductDto> GetProductsByProductLine(string productLine);
        void DeleteProduct(ProductDto product);
        ProductDto AddProduct(ProductDto product);
        ProductDto UpdateProduct(ProductDto product);
    }
}
