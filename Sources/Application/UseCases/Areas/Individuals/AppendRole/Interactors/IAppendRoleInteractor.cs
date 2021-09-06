using System.Threading.Tasks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Dto;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Interactors
{
    public interface IAppendRoleInteractor
    {
        Task ExecuteAsync(long individualId, AppendRoleRequestDto dto);
    }
}