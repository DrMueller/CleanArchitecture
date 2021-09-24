using System.Threading.Tasks;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.DeleteIndividual.Interactors
{
    public interface IDeleteIndividualInteractor
    {
        Task ExecuteAsync(long individualId);
    }
}