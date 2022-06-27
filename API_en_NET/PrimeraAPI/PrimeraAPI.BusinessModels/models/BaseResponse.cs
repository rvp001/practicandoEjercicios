namespace PrimeraAPI.BusinessModels.models
{
    public class BaseResponse<T>
    {
        public T Results { get; set; }
        public string Error { get; set; }
    }
}
