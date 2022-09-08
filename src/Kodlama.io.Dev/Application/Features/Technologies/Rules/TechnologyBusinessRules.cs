using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
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

        public async Task TechnologyNameCanNotBeDuplicateWhenInserted(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Technology Name Already Exists!");
        }
    }
}
