using PrimeraAPI.BusinessModels.models.Productline;
using PrimeraAPI.DataAccess.Contracts.Models;

namespace PrimeraAPI.Application.Mappers
{
    public static class ProductLineMapper
    {
        public static ProductLineDto MapToProductLineDtoFromCreateProductLineRequest(CreateProductLineRequest request)
        {
            return new ProductLineDto
            {
                ProductLineCode = request.Code,
                HtmlDescription = request.HtmlDescription,
                Image = request.Image,
                TextDescription = request.TextDescription
            };
        }

        public static ProductLineResponse MapToProductLineResponseFromProductLineDto(ProductLineDto product)
        {
            return new ProductLineResponse
            {
                Code = product.ProductLineCode,
                HtmlDescription = product.HtmlDescription,
                Image = product.Image,
                TextDescription = product.TextDescription
            };
        }

        public static List<ProductLineResponse> MapToProductLineResponseListFromProductLineDtoList(List<ProductLineDto> products)
        {
            //var query = from p in products
            //            select MapToProductResponseFromProductDto(p);

            //return query.ToList();

            return products.Select(p => MapToProductLineResponseFromProductLineDto(p)).ToList();
        }
    }
}
