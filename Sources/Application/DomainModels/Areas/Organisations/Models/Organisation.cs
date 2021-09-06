using System.Collections.Generic;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Roles.Models;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Organisations.Models
{
    public class Organisation : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}