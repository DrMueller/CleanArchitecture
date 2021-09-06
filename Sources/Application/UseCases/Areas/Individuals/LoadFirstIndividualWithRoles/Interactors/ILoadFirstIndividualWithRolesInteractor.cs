using System.Threading.Tasks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Interactors
{
    public interface ILoadFirstIndividualWithRolesInteractor
    {
        Task<IndividualWithRolesDto> ExecuteAsync();
    }
}