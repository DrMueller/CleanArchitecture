using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Base.Implementation;
using Mmu.CleanArchitecture.DomainModels.Areas.Organisations.Models;
using Mmu.CleanArchitecture.DomainServices.Areas.Organisations.Repositories;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Organisations.Implementation
{
    public class OrganisationRepository : RepositoryBase<Organisation>, IOrganisationRepository
    {
        public async Task<IReadOnlyCollection<Organisation>> LoadAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}