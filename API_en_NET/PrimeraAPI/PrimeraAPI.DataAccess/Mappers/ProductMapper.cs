using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Entities;

namespace PrimeraAPI.DataAccess.Mappers
{
    public static class ProductMapper
    {
        public static Product MapToProductFromProductDto(ProductDto product)
        {
            return new Product
            {
                BuyPrice = product.BuyPrice,
                Msrp = product.Msrp,
                ProductCode = product.ProductCode,
                ProductDescription = product.ProductDescription,
                ProductLine = product.ProductLine,
                ProductName = product.ProductName,
                ProductScale = product.ProductScale,
                ProductVendor = product.ProductVendor,
                QuantityInStock = product.QuantityInStock
            };
        }

        public static ProductDto MapToProductDtoFromProduct(Product product)
        {
            return new ProductDto
            {
                BuyPrice = product.BuyPrice,
                Msrp = product.Msrp,
                ProductCode = product.ProductCode,
                ProductDescription = product.ProductDescription,
                ProductLine = product.ProductLine,
                ProductName = product.ProductName,
                ProductScale = product.ProductScale,
                ProductVendor = product.ProductVendor,
                QuantityInStock = product.QuantityInStock
            };
        }
    }
}
