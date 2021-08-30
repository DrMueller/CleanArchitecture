using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Roles;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Organisations
{
    public class Organisation : EntityBase
    {
        public ICollection<Role> Roles { get; set; }

        public string Name { get; set; }
    }
}
