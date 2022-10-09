using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Auths.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task EmailCanNotBeDublicatedWhenRegistered(string email)
    {
        User? user = await _userRepository.GetAsync(x => x.Email == email);
        if (user != null) throw new BusinessException("Email already registered.");
    }

    public void UserShouldExistWhenRequested(User? user)
    {
        if (user == null) throw new BusinessException("User not found!");
    }

    public void UserCredentialsShouldMatchWhenLoggingIn(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt)) 
            throw new BusinessException("Email or password is incorrect!");
    }
}