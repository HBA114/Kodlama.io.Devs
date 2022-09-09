using Application.Features.GithubLinks.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GithubLinks.Queries
{
    public class GetListGithubLinkQuery : IRequest<GithubLinkListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetlistGithubLinkQueryHandler : IRequestHandler<GetListGithubLinkQuery, GithubLinkListModel>
        {
            private readonly IGithubLinkRepository _userLinkRepository;
            private readonly IMapper _mapper;

            public GetlistGithubLinkQueryHandler(IGithubLinkRepository userLinkRepository, IMapper mapper)
            {
                _userLinkRepository = userLinkRepository;
                _mapper = mapper;
            }

            public async Task<GithubLinkListModel> Handle(GetListGithubLinkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GithubLink> userLinks = await _userLinkRepository.GetListAsync(
                    include: u => u.Include(c => c.User),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );

                GithubLinkListModel mappedUserLinks = _mapper.Map<GithubLinkListModel>(userLinks);
                return mappedUserLinks;
            }
        }
    }
}
