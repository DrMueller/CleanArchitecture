using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.UseCases.Areas.Organisations.LoadAllOrganisations.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Organisations.LoadAllOrganisations.Interactors
{
    public interface ILoadAllOrganisationsInteractor
    {
        Task<IReadOnlyCollection<OrganisationDto>> ExecuteAsync();
    }
}