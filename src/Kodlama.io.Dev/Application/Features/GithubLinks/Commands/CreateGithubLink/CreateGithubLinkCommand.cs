// using Application.Features.AppUsers.Rules;
// using Application.Features.GithubLinks.Dtos;
// using Application.Features.GithubLinks.Rules;
// using Application.Services.Repositories;
// using AutoMapper;
// using Core.Application.Pipelines.Authorization;
// using Domain.Entities;
// using MediatR;

// namespace Application.Features.GithubLinks.Commands.CreateGithubLink
// {
//     public class CreateGithubLinkCommand : IRequest<CreatedGithubLinkDto>, ISecuredRequest
//     {
//         public int UserId { get; set; }
//         public string Url { get; set; }

//         public string[] Roles { get; } = { "user" }; // ?? 

//         public class CreateGithubLinkCommandHandler : IRequestHandler<CreateGithubLinkCommand, CreatedGithubLinkDto>
//         {
//             private readonly IGithubLinkRepository _githubLinkRepository;
//             private readonly IMapper _mapper;
//             private readonly GithubLinkBusinessRules _githubLinkBusinessRules;
//             private readonly UserBusinessRules _userBusinessRules;

//             public CreateGithubLinkCommandHandler(IGithubLinkRepository githubLinkRepository, IMapper mapper, GithubLinkBusinessRules githubLinkBusinessRules, UserBusinessRules userBusinessRules)
//             {
//                 _githubLinkRepository = githubLinkRepository;
//                 _mapper = mapper;
//                 _githubLinkBusinessRules = githubLinkBusinessRules;
//                 _userBusinessRules = userBusinessRules;
//             }

//             public async Task<CreatedGithubLinkDto> Handle(CreateGithubLinkCommand request, CancellationToken cancellationToken)
//             {
//                 await _userBusinessRules.UserShouldExistWhenRequested(request.UserId);
//                 await _githubLinkBusinessRules.CanNotAddSeconLinkToUser(request.UserId);

//                 GithubLink mappedUserLink = _mapper.Map<GithubLink>(request);
//                 GithubLink createdUserLink = await _githubLinkRepository.AddAsync(mappedUserLink);

//                 CreatedGithubLinkDto result = _mapper.Map<CreatedGithubLinkDto>(createdUserLink);
//                 return result;
//             }
//         }
//     }
// }
