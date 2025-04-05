using GhostVillages.DataAccess.Entities;

namespace GhostVillages.Application.Services
{
    public interface IRegionService
    {
        Task<RegionEntity> Create(string title, string description, byte[] image);
        Task<RegionEntity?> Get(Guid id);
        Task<List<RegionEntity>> GetList();
        Task<bool> Remove(Guid id);
        Task<RegionEntity?> Update(Guid id, string title, string description, byte[] image);
    }
}