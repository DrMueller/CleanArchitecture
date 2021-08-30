using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanArchitecture.DataAccess.Areas.TypeConfigurations.Base;
using Mmu.CleanArchitecture.DomainModels.Areas.Organisations;
using Mmu.CleanArchitecture.DomainModels.Areas.Roles;

namespace Mmu.CleanArchitecture.DataAccess.Areas.TypeConfigurations.Organisations
{
    public class OrganisationConfig : EntityConfigBase<Organisation>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Organisation> builder)
        {
            builder.Property(f => f.Name).HasMaxLength(100).IsRequired();
            builder.ToTable(nameof(Organisation), Constants.Schemas.Organisations);
        }
    }
}
