using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.TechnologyNameCanNotBeDuplicateWhenInserted(request.Name);
                await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistsWhenRequested(request.ProgrammingLanguageId);

                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
                CreatedTechnologyDto result = _mapper.Map<CreatedTechnologyDto>(createdTechnology);

                return result;
            }
        }
    }
}
