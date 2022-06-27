using PrimeraAPI.DataAccess.Contracts.Models;

namespace PrimeraAPI.DataAccess.Contracts.Repositories
{
    public interface IProductLineRepository
    {
        PaginatedDto<ProductLineDto> GetProductLinesPaginated(string description = "", int page = 1, int itemsPerPage = 5);

        ProductLineDto? GetProductLineByCode(string productLineCode);

        void DeleteProductLine(ProductLineDto product);

        ProductLineDto AddProductLine(ProductLineDto productLine);

        ProductLineDto UpdateProductLine(ProductLineDto productLine);
    }
}
