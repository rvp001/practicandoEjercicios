using PrimeraAPI.BusinessModels.models.Product;
using PrimeraAPI.DataAccess.Contracts.Models;

namespace PrimeraAPI.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto MapToProductDtoFromCreateProductRequest(CreateProductRequest request)
        {
            return new ProductDto
            {
                BuyPrice = request.BuyPrice,
                Msrp = request.Price,
                ProductCode = request.Code,
                ProductDescription = request.Description,
                ProductLine = request.Line,
                ProductName = request.Name,
                ProductScale = request.Scale,
                ProductVendor = request.Vendor,
                QuantityInStock = request.Stock
            };
        }

        public static ProductResponse MapToProductResponseFromProductDto(ProductDto product)
        {
            return new ProductResponse
            {
                BuyPrice = product.BuyPrice,
                Price = product.Msrp,
                Code = product.ProductCode,
                Description = product.ProductDescription,
                Line = product.ProductLine,
                Name = product.ProductName,
                Scale = product.ProductScale,
                Stock = product.QuantityInStock,
                Vendor = product.ProductVendor
            };
        }

        public static List<ProductResponse> MapToProductResponseListFromProductDtoList(List<ProductDto> products)
        {
            //var query = from p in products
            //            select MapToProductResponseFromProductDto(p);

            //return query.ToList();

            return products.Select(p => MapToProductResponseFromProductDto(p)).ToList();
        }
    }
}
