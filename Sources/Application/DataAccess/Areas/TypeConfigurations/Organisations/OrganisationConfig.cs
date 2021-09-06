using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanArchitecture.DataAccess.Areas.TypeConfigurations.Base;
using Mmu.CleanArchitecture.DomainModels.Areas.Organisations.Models;

namespace Mmu.CleanArchitecture.DataAccess.Areas.TypeConfigurations.Organisations
{
    public class OrganisationConfig : EntityConfigBase<Organisation>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Organisation> builder)
        {
            builder.Property(f => f.Name).HasMaxLength(100).IsRequired();
            builder.ToTable(nameof(Organisation), Schemas.Organisations);
        }
    }
}