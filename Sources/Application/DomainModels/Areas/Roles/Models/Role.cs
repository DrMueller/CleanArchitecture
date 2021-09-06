using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Organisations.Models;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Roles.Models
{
    public class Role : EntityBase
    {
        public string Description { get; set; }

        public Individual Individual { get; set; }

        public Organisation Organisation { get; set; }
    }
}