using PrimeraAPI.DataAccess.Contracts.Models;

namespace PrimeraAPI.DataAccess.Contracts.Repositories
{
    public interface IUserRepository
    {
        UserDto? ValidateUser(string userName, string password);
    }
}
