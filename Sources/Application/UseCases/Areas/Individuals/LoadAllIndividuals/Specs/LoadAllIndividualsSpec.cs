using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Specs
{
    internal class LoadAllIndividualsSpec : ISpecification<Individual, IndividualResultDto>
    {
        public Expression<Func<Individual, IndividualResultDto>> Selector
        {
            get
            {
                return ind => new IndividualResultDto
                {
                    BirthDate = ind.BirthDate,
                    FirstName = ind.FirstName,
                    GenderDescription = ind.Gender == Gender.Male ? IndividualResultDto.GenderMale : IndividualResultDto.GenderFemale,
                    LastName = ind.LastName,
                    IndividualId = ind.Id
                };
            }
        }

        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry.OrderBy(f => f.FirstName);
        }
    }
}