using System;

namespace Mmu.CleanArchitecture.DomainModels.Areas.Base.Models
{
    public abstract class EntityBase
    {
        public DateTime CreatedDate { get; set; }
        public long Id { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}