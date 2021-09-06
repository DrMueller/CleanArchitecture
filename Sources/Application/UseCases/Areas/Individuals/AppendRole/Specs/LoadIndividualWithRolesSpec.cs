using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;

namespace Mmu.CleanArchitecture.UseCases.Areas.Individuals.AppendRole.Specs
{
    public class LoadIndividualWithRolesSpec : ISpecification<Individual>
    {
        private readonly long _individualId;

        public LoadIndividualWithRolesSpec(long individualId)
        {
            _individualId = individualId;
        }

        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry
                .Include(f => f.Roles)
                .Where(f => f.Id == _individualId);
        }
    }
}