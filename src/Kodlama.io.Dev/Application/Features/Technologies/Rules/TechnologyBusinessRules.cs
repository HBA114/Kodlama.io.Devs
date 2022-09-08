using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyShouldExistWhenRequested(int id)
        {
            Technology? technology = await _technologyRepository.GetAsync(t => t.Id == id);
            if (technology == null) throw new BusinessException("Requested Technology Does Not Exists.");
        }
    }
}
