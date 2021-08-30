using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Base;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Roles;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Individuals
{
    public class Individual : EntityBase
    {
        public ICollection<Role> Roles { get; set; }

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public string LastName { get; set; }

    }
}
