using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostVillages.DataAccess.Entities
{
    public class RegionEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public virtual ICollection<VillageEntity> Villages { get; set; } = [];
    }
}
