using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Organisations.Models;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.Repositories;

namespace Mmu.CleanArchitecture.DomainServices.Areas.Organisations.Repositories
{
    public interface IOrganisationRepository : IRepository<Organisation>
    {
        Task<IReadOnlyCollection<Organisation>> LoadAllAsync();
    }
}