using Techwiz.Models;

namespace Techwiz.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(uint id);
        Task<User> CreateUserAsync(User user);
    }
}