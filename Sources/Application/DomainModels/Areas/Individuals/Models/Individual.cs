using System;
using System.Collections.Generic;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Roles.Models;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models
{
    public class Individual : EntityBase
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public string LastName { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}