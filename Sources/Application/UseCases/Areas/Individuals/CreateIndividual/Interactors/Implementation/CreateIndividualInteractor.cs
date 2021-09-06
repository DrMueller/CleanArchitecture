using System;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.CrossCutting.Areas.Logging.Services;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;
using Mmu.CleanArchitecture.DomainServices.Areas.Common.UnitOfWorks;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Interactors.Implementation
{
    public class CreateIndividualInteractor : ICreateIndividualInteractor
    {
        private readonly ILoggingService _loggingService;
        private readonly IUnitOfWorkFactory _uowFactory;

        public CreateIndividualInteractor(
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
                FirstName = dto.FirstName + " " + Guid.NewGuid(),
                Gender = dto.Gender,
                LastName = dto.LastName + " " + Guid.NewGuid()
            };

            using (var uow = _uowFactory.Create())
            {
                var individualRepo = uow.GetGenericRepository<Individual>();
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