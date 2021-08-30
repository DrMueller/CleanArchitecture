using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals;
using Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Dtos;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadAllIndividuals.Specifications
{
    internal class LoadAllIndividualsSpecification :  SpecificationBase<Individual>, ISelectSpecification<Individual, LoadedIndividualResultDto>
    {
        public LoadAllIndividualsSpecification()
        {
            AddOrderBy(f => f.FirstName);
            AddInclude(f => f.Roles);
        }

        public Expression<Func<Individual, LoadedIndividualResultDto>> Selector
        {
            get
            {
                return ind => new LoadedIndividualResultDto
                {
                    BirthDate = ind.BirthDate,
                    FirstName = ind.FirstName,
                    Gender = ind.Gender,
                    LastName = ind.LastName
                };
            }
        }
    }
}
