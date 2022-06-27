using PrimeraAPI.BusinessModels.Models.Users;

namespace PrimeraAPI.Application.Contracts.Services
{
    public interface IUserService
    {
        UserResponse? ValidateUser(LoginRequest request);
    }
}
