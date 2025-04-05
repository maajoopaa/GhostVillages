using GhostVillages.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostVillages.DataAccess
{
    public class GhostVillagesDbContext : DbContext
    {
        public GhostVillagesDbContext(DbContextOptions<GhostVillagesDbContext> options)
            : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<VillageEntity> Villages { get; set; }

        public DbSet<RegionEntity> Regions { get; set; }
    }
}
