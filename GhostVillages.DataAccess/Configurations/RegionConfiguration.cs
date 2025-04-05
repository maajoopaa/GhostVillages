using GhostVillages.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostVillages.DataAccess.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<RegionEntity>
    {
        public void Configure(EntityTypeBuilder<RegionEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Villages)
                .WithOne(v => v.Region)
                .HasForeignKey(v => v.RegionId);
        }
    }
}
