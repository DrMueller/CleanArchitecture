using System;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.CreateIndividual.Dtos
{
    public class CreateIndividualRequestDto
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public string LastName { get; set; }
    }
}