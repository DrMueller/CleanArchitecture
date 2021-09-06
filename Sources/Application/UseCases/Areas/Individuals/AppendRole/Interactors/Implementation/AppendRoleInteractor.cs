using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Organisations.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Roles.Models;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.UnitOfWorks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Dto;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Specs;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Interactors.Implementation
{
    public class AppendRoleInteractor : IAppendRoleInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public AppendRoleInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long individualId, AppendRoleRequestDto dto)
        {
            using var uow = _uowFactory.Create();

            var indRepo = uow.GetGenericRepository<Individual>();
            var spec = new LoadIndividualWithRolesSpec(individualId);
            var individual = await indRepo.LoadAsync(spec);

            individual.Roles.Add(
                new Role
                {
                    Description = dto.RoleDescription,
                    Organisation = new Organisation
                    {
                        Name = dto.OrganisationName
                    }
                });

            await uow.SaveAsync();
        }
    }
}