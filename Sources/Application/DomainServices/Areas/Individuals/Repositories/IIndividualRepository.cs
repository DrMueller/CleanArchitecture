using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.Repositories;

namespace Mmu.CleanArchitecture.DomainServices.Areas.Individuals.Repositories
{
    public interface IIndividualRepository : IRepository
    {
        Task<Individual> LoadByIdAsync(long id);

        Task UpsertAsync(Individual individual);
    }
}