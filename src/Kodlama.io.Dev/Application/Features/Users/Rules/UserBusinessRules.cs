using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.AppUsers.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            User? user = await _userRepository.GetAsync(p => p.Email == email);
            if (user != null) throw new BusinessException("Email Already In Use!");
        }

        public async Task UserShouldExistWhenRequested(string email)
        {
            User? user = await _userRepository.GetAsync(p => p.Email == email);
            if (user == null) throw new BusinessException("Email Not Registered!");
        }

        public async Task UserShouldExistWhenRequested(int id)
        {
            User? user = await _userRepository.GetAsync(p => p.Id == id);
            if (user == null) throw new BusinessException("User Not Found!");
        }
    }
}
