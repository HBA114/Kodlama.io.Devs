using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppUsers.Commands.RegisterAppUser
{
    public class RegisterUserCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public class RegisterAppUserCommandHandler : IRequestHandler<RegisterUserCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IUserOperationClaimsRepository _userOperationClaimsRepository;
            private readonly ITokenHelper _tokenHelper;

            public RegisterAppUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, IUserOperationClaimsRepository userOperationClaimsRepository, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _userOperationClaimsRepository = userOperationClaimsRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);
                
                Byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                User user = _mapper.Map<User>(request);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Status = true;

                User registeredAppUser = await _userRepository.AddAsync(user);

                UserOperationClaim userOperationClaim = new() { UserId = registeredAppUser.Id, OperationClaimId = 1 };

                IPaginate<UserOperationClaim> userGetClaims = await _userOperationClaimsRepository.GetListAsync(
                    u => u.UserId == registeredAppUser.Id,
                include: i => i.Include(i => i.OperationClaim));

                AccessToken accessToken = _tokenHelper.CreateToken(user, userGetClaims.Items.Select(u => u.OperationClaim).ToList());
                return accessToken;
            }
        }
    }
}
