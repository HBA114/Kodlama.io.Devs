using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, TechnologyGetByIdDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<TechnologyGetByIdDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.TechnologyShouldExistWhenRequested(request.Id);

                Technology technology = await _technologyRepository.GetAsync(p => p.Id == request.Id);
                await _technologyRepository.DeleteAsync(technology);

                TechnologyGetByIdDto result = _mapper.Map<TechnologyGetByIdDto>(technology);

                return result;
            }
        }
    }
}
