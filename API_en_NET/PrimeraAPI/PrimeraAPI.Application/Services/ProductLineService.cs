using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.Application.Mappers;
using PrimeraAPI.BusinessModels.models;
using PrimeraAPI.BusinessModels.models.Productline;
using PrimeraAPI.BusinessModels.models.Product;
using PrimeraAPI.CrossCutting.Contracts.Services;
using PrimeraAPI.DataAccess.Contracts;
using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Contracts.Repositories;

namespace PrimeraAPI.Application.Services
{
    public class ProductLineService : IProductLineService
    {
        private IProductLineRepository _productLineRepository;
        private IUnitOfWork _uOw;
        private IProductService _productService;
        private ICacheService _cacheService;

        public ProductLineService(IProductLineRepository productLineRepository,
                                  IUnitOfWork uOw,
                                  IProductService productService,
                                  ICacheService cacheService)
        {
            _productLineRepository = productLineRepository;
            _uOw = uOw;
            _productService = productService;
            _cacheService = cacheService;
        }

        public PaginatedResponse<ProductLineResponse> GetProductLinesPaginated(ProductLineSearchRequest request)
        {
            PaginatedResponse<ProductLineResponse> result = new PaginatedResponse<ProductLineResponse>();

            PaginatedDto<ProductLineDto> search = _productLineRepository.GetProductLinesPaginated(request.Description, request.Page.Value, request.ItemsPerPage.Value);

            result.Results = ProductLineMapper.MapToProductLineResponseListFromProductLineDtoList(search.Results);
            result.Total = search.Total;
            result.Page = search.Page;
            result.ItemsPerPage = search.ItemsPerPage;

            return result;
        }

        public ProductLineResponse? GetProductByCode(string code)
        {
            //Llamada al repositorio
            //ProductLineDto? product = _productLineRepository.GetProductLineByCode(code);
            string cacheKey = $"ProductLines_{code}";

            ProductLineDto? product = _cacheService.GetUsingCache(cacheKey, () => _productLineRepository.GetProductLineByCode(code));

            if (product != null)
            {
                //Mapeo de ProductDto a ProductResponse
                ProductLineResponse result = ProductLineMapper.MapToProductLineResponseFromProductLineDto(product);

                return result;
            }
            else return null;
        }

        public BaseResponse<bool> DeleteProductLine(string productCode)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();

            ProductLineDto? productLine = _productLineRepository.GetProductLineByCode(productCode);

            if (productLine != null)
            {
                List<ProductResponse> products = _productService.GetProductsByProductLine(productCode);

                if (products == null || products.Count == 0)
                {
                    _productLineRepository.DeleteProductLine(productLine);

                    _uOw.Commit();

                    result.Results = true;
                }
                else
                {
                    result.Results = false;
                    result.Error = "No se puede eliminar la linea de producto porque tiene productos asociados";
                }

            }
            else
            {
                result.Results = false;
                result.Error = "No se puede eliminar la linea de producto porque no existe";
            }

            return result;
        }

        public ProductLineResponse? AddProductLine(CreateProductLineRequest request)
        {

            ProductLineDto? existingProductLine = _productLineRepository.GetProductLineByCode(request.Code);

            if (existingProductLine == null)
            {
                ProductLineDto productLineToInsert = ProductLineMapper.MapToProductLineDtoFromCreateProductLineRequest(request);

                ProductLineDto productLineInserted = _productLineRepository.AddProductLine(productLineToInsert);

                _uOw.Commit();

                ProductLineResponse result = ProductLineMapper.MapToProductLineResponseFromProductLineDto(productLineInserted);

                return result;
            }
            else return null;
        }

        public ProductLineResponse? UpdateProductLine(string code, UpdateProductLineRequest request)
        {

            ProductLineDto? existingProductLine = _productLineRepository.GetProductLineByCode(code);

            if (existingProductLine != null)
            {
                existingProductLine.HtmlDescription = request.HtmlDescription;
                existingProductLine.Image = request.Image;
                existingProductLine.TextDescription = request.TextDescription;

                ProductLineDto productLineUpdated = _productLineRepository.UpdateProductLine(existingProductLine);

                _uOw.Commit();

                string cacheKey = $"ProductLines_{code}";
                _cacheService.DeleteFromCache(cacheKey);

                ProductLineResponse result = ProductLineMapper.MapToProductLineResponseFromProductLineDto(productLineUpdated);

                return result;
            }
            else return null;
        }
    }
}
