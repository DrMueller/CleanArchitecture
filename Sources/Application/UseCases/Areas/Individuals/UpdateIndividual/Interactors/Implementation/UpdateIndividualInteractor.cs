using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Common.Specs;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.UnitOfWorks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.UpdateIndividual.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.UpdateIndividual.Interactors.Implementation
{
    public class UpdateIndividualInteractor : IUpdateIndividualInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public UpdateIndividualInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long individualId, IndividualToUpdateDto dto)
        {
            using var uow = _uowFactory.Create();
            var indRepo = uow.GetGenericRepository<Individual>();

            var individualByIdSpec = new EntityByIdSpec<Individual>(individualId);
            var ind = await indRepo.LoadAsync(individualByIdSpec);
            ind.FirstName = dto.NewFirstName;

            await uow.SaveAsync();
        }
    }
}
