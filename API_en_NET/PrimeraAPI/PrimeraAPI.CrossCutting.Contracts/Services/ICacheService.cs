namespace PrimeraAPI.CrossCutting.Contracts.Services
{
    public interface ICacheService
    {
        T GetUsingCache<T>(string cacheKey, Func<T> getFunction) where T : class;

        T GetUsingCache<T, U>(string cacheKey, Func<U, T> getFunction, U functionParameter) where T : class;

        void DeleteFromCache(string cacheKey);
    }
}
