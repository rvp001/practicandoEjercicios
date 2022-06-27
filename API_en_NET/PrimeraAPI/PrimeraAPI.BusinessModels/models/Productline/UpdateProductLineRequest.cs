namespace PrimeraAPI.BusinessModels.models.Productline
{
    public class UpdateProductLineRequest
    {
        public string? TextDescription { get; set; }
        public string? HtmlDescription { get; set; }
        public byte[]? Image { get; set; }
    }
}
