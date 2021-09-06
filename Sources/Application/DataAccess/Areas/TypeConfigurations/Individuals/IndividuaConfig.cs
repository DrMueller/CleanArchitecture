using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanArchitecture.DataAccess.Areas.TypeConfigurations.Base;
using Mmu.CleanArchitecture.DomainModels.Areas.Individuals.Models;

namespace Mmu.CleanArchitecture.DataAccess.Areas.TypeConfigurations.Individuals
{
    public class IndividuaConfig : EntityConfigBase<Individual>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Individual> builder)
        {
            builder.Property(f => f.BirthDate).IsRequired();
            builder.Property(f => f.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Gender).IsRequired();
            builder.Property(f => f.LastName).HasMaxLength(100).IsRequired();
            builder.ToTable(nameof(Individual), Schemas.Individuals);
        }
    }
}