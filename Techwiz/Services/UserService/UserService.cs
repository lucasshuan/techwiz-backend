using Techwiz.Models;
using Techwiz.Repositories;

namespace Techwiz.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByIdAsync(uint id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> CreateUserAsync(CreateUserModel input)
        {
            var user = new User
            {
                Name = input.Name,
                Email = input.Email,
                PasswordHash = input.Password,
            };
            return await _userRepository.CreateUserAsync(user);
        }
    }
}