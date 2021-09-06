using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Interactors
{
    public interface ILoadAllIndividualsInteractor
    {
        Task<IReadOnlyCollection<IndividualResultDto>> ExecuteAsync();
    }
}