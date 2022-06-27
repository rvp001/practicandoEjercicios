namespace PrimeraAPI.BusinessModels.models
{
    public class PaginatedResponse<T> where T : class
    {
        public List<T> Results { get; set; }

        public int Total { get; set; }
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public PaginatedResponse()
        {
            // para que no sea nunca nulo y por lo menos sea una lista vacia y asi no hay que ponerle el .result.
            Results = new List<T>();
        }
    }
}
