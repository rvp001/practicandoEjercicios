namespace PrimeraAPI.DataAccess.Contracts.Models
{
    public class PaginatedDto<T> where T : class
    {
        public List<T> Results { get; set; }
        
        public int Total { get; set; }
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public PaginatedDto()
        {
            // para que no sea nunca nulo y por lo menos sea una lista vacia
            Results = new List<T>();
        }        
    }
}
