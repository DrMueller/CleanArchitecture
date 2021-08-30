using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals;
using Mmu.CleanArchitecture.DomainModels.Areas.Organisations;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Roles
{
    public class Role : EntityBase
    {
        public string Description { get; set; }

        public Individual Individual { get; set; }

        public Organisation Organisation { get; set; }
    }
}