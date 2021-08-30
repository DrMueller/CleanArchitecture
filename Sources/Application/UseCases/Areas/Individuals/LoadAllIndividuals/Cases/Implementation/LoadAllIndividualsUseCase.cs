using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.Querying.Services;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Specifications;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Cases.Implementation
{
    public class LoadAllIndividualsUseCase : ILoadAllIndividualsUseCase
    {
        private readonly IQueryService _queryService;

        public LoadAllIndividualsUseCase(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<LoadedIndividualResultDto>> ExecuteAsync()
        {
            var dtos = await _queryService.QueryAsync(new LoadAllIndividualsSpecification());

            return dtos;
        }
    }
}
