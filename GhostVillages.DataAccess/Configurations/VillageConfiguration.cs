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
    public class VillageConfiguration : IEntityTypeConfiguration<VillageEntity>
    {
        public void Configure(EntityTypeBuilder<VillageEntity> builder)
        {
            builder.HasKey(v => v.Id);
        }
    }
}
