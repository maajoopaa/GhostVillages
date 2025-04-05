namespace GhostVillages.Models
{
    public class VillageRequest
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public string RegionId { get; set; } = null!;
    }
}
