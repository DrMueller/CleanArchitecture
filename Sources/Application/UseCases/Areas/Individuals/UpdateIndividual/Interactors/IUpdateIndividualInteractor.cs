using System.Threading.Tasks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.UpdateIndividual.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.UpdateIndividual.Interactors
{
    public interface IUpdateIndividualInteractor
    {
        Task ExecuteAsync(long individualId, IndividualToUpdateDto dto);
    }
}
