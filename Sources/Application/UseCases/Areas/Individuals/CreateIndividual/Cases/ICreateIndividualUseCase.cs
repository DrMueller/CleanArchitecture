using System.Threading.Tasks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Cases
{
    public interface ICreateIndividualUseCase
    {
        Task<CreateIndividualResultDto> ExecuteAsync(CreateIndividualRequestDto dto);
    }
}