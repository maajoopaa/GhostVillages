using GhostVillages.DataAccess.Entities;

namespace GhostVillages.Application.Services
{
    public interface IVillageService
    {
        Task<VillageEntity> Create(string title, string description, byte[] image, Guid regionId);
        Task<VillageEntity?> Get(Guid id);
        Task<List<VillageEntity>> GetList(Guid regionId);
        Task<bool> Remove(Guid id);
        Task<List<VillageEntity>> Search(string query);
        Task<VillageEntity?> Update(Guid id, string title, string description, byte[] image, Guid regionId);
    }
}