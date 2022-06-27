using PrimeraAPI.BusinessModels.models;
using PrimeraAPI.BusinessModels.models.Product;

namespace PrimeraAPI.Application.Contracts.Services
{
    public interface IProductService
    {
        PaginatedResponse<ProductResponse> GetProductsPaginated(ProductSearchRequest request);
        List<ProductResponse> GetProductsByProductLine(string productLine);
        ProductResponse? GetProductByCode(string code);
        bool DeleteProduct(string productCode);
        ProductResponse? AddProduct(CreateProductRequest request);
        ProductResponse? UpdateProduct(string code, UpdateProductRequest request);
    }
}
