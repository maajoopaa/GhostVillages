using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostVillages.DataAccess.Entities
{
    public class VillageEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public Guid RegionId { get; set; }

        public virtual RegionEntity Region { get; set; } = null!;
    }
}
