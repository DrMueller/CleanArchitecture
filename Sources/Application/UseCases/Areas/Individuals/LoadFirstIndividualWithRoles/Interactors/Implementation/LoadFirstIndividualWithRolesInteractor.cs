using System.Linq;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.Querying.Services;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Specs;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Interactors.Implementation
{
    public class LoadFirstIndividualWithRolesInteractor : ILoadFirstIndividualWithRolesInteractor
    {
        private readonly IQueryService _queryService;

        public LoadFirstIndividualWithRolesInteractor(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IndividualWithRolesDto> ExecuteAsync()
        {
            var individuals = await _queryService.QueryAsync(new LoadIndividualsWithRolesSpec());
            var dto = individuals.Select(
                ind => new IndividualWithRolesDto
                {
                    AmountOfRoles = ind.Roles.Count,
                    IndividualId = ind.Id
                }).First();

            return dto;
        }
    }
}