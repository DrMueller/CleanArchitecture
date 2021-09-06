using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.UnitOfWorks;
using Mmu.CleanArchitecture.DomainServices.Areas.Organisations.Repositories;
using Mmu.CleanArchitecture.UseCases.Areas.Organisations.LoadAllOrganisations.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Organisations.LoadAllOrganisations.Interactors.Implementation
{
    public class LoadAllOrganisationsInteractor : ILoadAllOrganisationsInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public LoadAllOrganisationsInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<IReadOnlyCollection<OrganisationDto>> ExecuteAsync()
        {
            using var uow = _uowFactory.Create();

            var orgRepo = uow.GetRepository<IOrganisationRepository>();
            var allOrgs = await orgRepo.LoadAllAsync();

            var dtos = allOrgs.Select(
                org => new OrganisationDto
                {
                    OrganisationId = org.Id,
                    OrganisationName = org.Name
                }).ToList();

            return dtos;
        }
    }
}