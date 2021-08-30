using System.Threading.Tasks;
using Mmu.CleanArchitecture.Application.Areas.Logging.Services;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.DataAccess.UnitOfWorks;
using Mmu.CleanArchitecture.DomainServices.Areas.Individuals.Repositories;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Dtos;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Cases.Implementation
{
    public class CreateIndividualUseCase : ICreateIndividualUseCase
    {
        private readonly ILoggingService _loggingService;
        private readonly IUnitOfWorkFactory _uowFactory;

        public CreateIndividualUseCase(
            ILoggingService loggingService,
            IUnitOfWorkFactory uowFactory)
        {
            _loggingService = loggingService;
            _uowFactory = uowFactory;
        }

        public async Task<CreateIndividualResultDto> ExecuteAsync(CreateIndividualRequestDto dto)
        {
            _loggingService.LogInformation("Creating new Individual..");

            var individual = new Individual
            {
                BirthDate = dto.BirthDate,
                FirstName = dto.FirstName,
                Gender = dto.Gender,
                LastName = dto.LastName
            };

            using (var uow = _uowFactory.Create())
            {
                var individualRepo = uow.GetRepository<IIndividualRepository>();
                await individualRepo.UpsertAsync(individual);
                await uow.SaveAsync();
            }

            _loggingService.LogInformation("Individual created");

            return new CreateIndividualResultDto
            {
                IndividualId = individual.Id
            };
        }
    }
}