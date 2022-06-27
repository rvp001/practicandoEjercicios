namespace PrimeraAPI.BusinessModels.models.Product
{
    public class ProductSearchRequest : PaginatedBaseRequest
    {
        public string Description { get; set; }
    }
}
