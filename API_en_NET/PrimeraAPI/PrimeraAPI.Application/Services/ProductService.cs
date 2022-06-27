using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.Application.Mappers;
using PrimeraAPI.BusinessModels.models;
using PrimeraAPI.BusinessModels.models.Product;
using PrimeraAPI.DataAccess.Contracts;
using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Contracts.Repositories;

namespace PrimeraAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _uOw;

        public ProductService(IProductRepository productRepository,
                              IUnitOfWork uOw)
        {
            _productRepository = productRepository;
            _uOw = uOw;
        }

        public PaginatedResponse<ProductResponse> GetProductsPaginated(ProductSearchRequest request)
        {
            PaginatedResponse<ProductResponse> result = new PaginatedResponse<ProductResponse>();

            PaginatedDto<ProductDto> search = _productRepository.GetProductsPaginated(request.Description, request.Page.Value, request.ItemsPerPage.Value);

            result.Results = ProductMapper.MapToProductResponseListFromProductDtoList(search.Results);
            result.Total = search.Total;
            result.Page = search.Page;
            result.ItemsPerPage = search.ItemsPerPage;

            return result;
        }

        public List<ProductResponse> GetProductsByProductLine(string productLine)
        {
            List<ProductDto> products = _productRepository.GetProductsByProductLine(productLine);

            return ProductMapper.MapToProductResponseListFromProductDtoList(products);
        }

        public ProductResponse? GetProductByCode(string code)
        {
            //Llamada al repositorio
            ProductDto? product = _productRepository.GetProductByCode(code);

            if (product != null)
            {
                //Mapeo de ProductDto a ProductResponse
                ProductResponse result = ProductMapper.MapToProductResponseFromProductDto(product);

                return result;
            }
            else return null;
        }

        public bool DeleteProduct(string productCode)
        {
            ProductDto? product = _productRepository.GetProductByCode(productCode);

            //TODO PSN: Completar la validacion de si tiene pedidos creados ese producto antes de borrar. En caso afirmativo, cancelar la operacion.

            if (product != null)
            {
                _productRepository.DeleteProduct(product);

                _uOw.Commit();

                return true;
            }
            else return false;
        }

        public ProductResponse? AddProduct(CreateProductRequest request)
        {

            ProductDto? existingProduct = _productRepository.GetProductByCode(request.Code);

            if (existingProduct == null)
            {
                ProductDto productToInsert = ProductMapper.MapToProductDtoFromCreateProductRequest(request);

                ProductDto productInserted = _productRepository.AddProduct(productToInsert);

                _uOw.Commit();

                ProductResponse result = ProductMapper.MapToProductResponseFromProductDto(productInserted);

                return result;
            }
            else return null;
        }

        public ProductResponse? UpdateProduct(string code, UpdateProductRequest request)
        {

            ProductDto? existingProduct = _productRepository.GetProductByCode(code);

            if (existingProduct != null)
            {
                existingProduct.ProductDescription = request.Description;
                existingProduct.BuyPrice = request.BuyPrice;
                existingProduct.Msrp = request.Price;
                existingProduct.ProductLine = request.Line;
                existingProduct.ProductName = request.Name;
                existingProduct.ProductScale = request.Scale;
                existingProduct.ProductVendor = request.Vendor;
                existingProduct.QuantityInStock = request.Stock;

                ProductDto productUpdated = _productRepository.UpdateProduct(existingProduct);

                _uOw.Commit();

                ProductResponse result = ProductMapper.MapToProductResponseFromProductDto(productUpdated);

                return result;
            }
            else return null;
        }
    }
}
