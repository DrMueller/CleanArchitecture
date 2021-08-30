using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Base.Implementation;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals;
using Mmu.CleanArchitecture.DomainServices.Areas.Individuals.Repositories;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Repositories.Individuals
{
    public class IndividualRepository : RepositoryBase<Individual>, IIndividualRepository
    {
        public async Task<Individual> LoadByIdAsync(long id)
        {
            return await LoadAsync(qry => qry.SingleAsync(f => f.Id == id));
        }
    }
}