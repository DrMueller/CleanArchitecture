using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.UnitOfWorks;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.DeleteIndividual.Interactors.Implementation
{
    public class DeleteIndividualInteractor : IDeleteIndividualInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public DeleteIndividualInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long individualId)
        {
            using var uow = _uowFactory.Create();

            var indRepo = uow.GetGenericRepository<Individual>();
            await indRepo.DeleteAsync(individualId);

            await uow.SaveAsync();
        }
    }
}