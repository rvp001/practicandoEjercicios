using PrimeraAPI.BusinessModels.models;
using PrimeraAPI.BusinessModels.models.Productline;

namespace PrimeraAPI.Application.Contracts.Services
{
    public interface IProductLineService
    {
        BaseResponse<bool> DeleteProductLine(string productCode);
        PaginatedResponse<ProductLineResponse> GetProductLinesPaginated(ProductLineSearchRequest request);
        ProductLineResponse? GetProductByCode(string code);
        ProductLineResponse? AddProductLine(CreateProductLineRequest request);
        ProductLineResponse? UpdateProductLine(string code, UpdateProductLineRequest request);
    }
}
