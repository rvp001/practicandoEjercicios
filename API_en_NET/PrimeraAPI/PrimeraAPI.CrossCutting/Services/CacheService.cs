using PrimeraAPI.CrossCutting.Contracts.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace PrimeraAPI.CrossCutting.Services
{
    public class CacheService : ICacheService
    {
        private IMemoryCache _cache;
        private IConfiguration _configuration;

        public CacheService(IMemoryCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;

        }

        public T GetUsingCache<T>(string cacheKey, Func<T> getFunction) where T : class
        {
            T element = null;

            element = GetElementFromCache<T>(cacheKey);

            if (element == null)
            {
                element = getFunction();

                AddElementToCache(cacheKey, element);
            }

            return element;
        }

        public T GetUsingCache<T, U>(string cacheKey, Func<U, T> getFunction, U functionParameter) where T : class
        {
            T element = null;

            element = GetElementFromCache<T>(cacheKey);

            if (element == null)
            {
                element = getFunction(functionParameter);

                AddElementToCache(cacheKey, element);
            }

            return element;
        }

        public void DeleteFromCache(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        private T GetElementFromCache<T>(string cacheKey) where T : class
        {
            T element = null;

            var elementJson = _cache.Get(cacheKey);

            if (elementJson != null)
            {
                element = JsonConvert.DeserializeObject<T>(elementJson.ToString());
            }

            return element;
        }

        private void AddElementToCache<T>(string cacheKey, T elementToStore) where T : class
        {
            if (elementToStore != null)
            {
                var elementJson = JsonConvert.SerializeObject(elementToStore);

                _cache.Set(cacheKey, elementJson, DateTime.Now.AddMinutes(int.Parse(_configuration.GetSection("CacheExpirationInMinutes").Value)));
            }
        }
    }
}
