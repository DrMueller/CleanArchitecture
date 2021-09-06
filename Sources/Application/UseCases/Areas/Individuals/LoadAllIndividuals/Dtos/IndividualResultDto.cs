using System;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos
{
    public class IndividualResultDto
    {
        public const string GenderFemale = "Female";
        public const string GenderMale = "Male";

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string GenderDescription { get; set; }

        public string LastName { get; set; }
    }
}