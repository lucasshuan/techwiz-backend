using Techwiz.Models;

namespace Techwiz.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(uint id);
        Task<User> CreateUserAsync(CreateUserModel input);
    }
}