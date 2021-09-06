using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.Querying.Services;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Specs;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Interactors.Implementation
{
    public class LoadAllIndividualsInteractor : ILoadAllIndividualsInteractor
    {
        private readonly IQueryService _queryService;

        public LoadAllIndividualsInteractor(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<IndividualResultDto>> ExecuteAsync()
        {
            var dtos = await _queryService.QueryAsync(new LoadAllIndividualsSpec());

            return dtos;
        }
    }
}