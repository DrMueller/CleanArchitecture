using System.Threading.Tasks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Interactors
{
    public interface ICreateIndividualInteractor
    {
        Task<CreateIndividualResultDto> ExecuteAsync(CreateIndividualRequestDto dto);
    }
}