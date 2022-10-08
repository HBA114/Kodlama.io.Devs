using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login;
public class AuthLoginCommand : IRequest<LoggedInDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IPAddress { get; set; }

    public class AuthLoginCommandHandler : IRequestHandler<AuthLoginCommand, LoggedInDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthService _authService;

        public AuthLoginCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IAuthService authService)
        {
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
            _authService = authService;
        }

        public async Task<LoggedInDto> Handle(AuthLoginCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserShouldExistWhenRequested(request.UserForLoginDto.Email);
            User user = await _userRepository.GetAsync(x => x.Email == request.UserForLoginDto.Email);
            _authBusinessRules.UserCredentialsShouldMatchWhenLoggingIn(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IPAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            LoggedInDto loggedInDto = new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken
            };


            return loggedInDto;
        }
    }
}