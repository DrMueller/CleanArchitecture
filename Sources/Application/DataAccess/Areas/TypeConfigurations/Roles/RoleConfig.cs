using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanArchitecture.DataAccess.Areas.TypeConfigurations.Base;
using Mmu.CleanArchitecture.DomainModels.Areas.Roles.Models;

namespace Mmu.CleanArchitecture.DataAccess.Areas.TypeConfigurations.Roles
{
    public class RoleConfig : EntityConfigBase<Role>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.Property(f => f.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(role => role.Individual)
                .WithMany(ind => ind.Roles)
                .IsRequired();

            builder.HasOne(role => role.Organisation)
                .WithMany(org => org.Roles)
                .IsRequired();

            builder.ToTable(nameof(Role), Schemas.Roles);
        }
    }
}