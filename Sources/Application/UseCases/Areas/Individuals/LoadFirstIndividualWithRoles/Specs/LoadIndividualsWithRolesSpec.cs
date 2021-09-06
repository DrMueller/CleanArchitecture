using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.LoadFirstIndividualWithRoles.Specs
{
    public class LoadIndividualsWithRolesSpec : ISpecification<Individual>
    {
        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry
                .Include(f => f.Roles)
                .Where(f => f.Roles.Any());
        }
    }
}