using GhostVillages.DataAccess;
using GhostVillages.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostVillages.Application.Services
{
    public class VillageService : IVillageService
    {
        private readonly GhostVillagesDbContext _context;

        public VillageService(GhostVillagesDbContext context)
        {
            _context = context;
        }

        public async Task<VillageEntity?> Get(Guid id)
        {
            var villageEntity = await _context.Villages
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == id);

            return villageEntity;
        }

        public async Task<List<VillageEntity>> GetList(Guid regionId)
        {
            var villageEntities = await _context.Villages
                .AsNoTracking()
                .Where(v => v.RegionId == regionId)
                .ToListAsync();

            return villageEntities;
        }

        public async Task<VillageEntity> Create(string title, string description, byte[] image, Guid regionId)
        {
            var villageEntity = new VillageEntity
            {
                Title = title,
                Description = description,
                Image = image,
                RegionId = regionId
            };

            await _context.Villages
                .AddAsync(villageEntity);

            await _context.SaveChangesAsync();

            return villageEntity;
        }

        public async Task<VillageEntity?> Update(Guid id, string title, string description, byte[] image, Guid regionId)
        {
            var villageEntity = await Get(id);

            if (villageEntity != null)
            {
                villageEntity.Title = title;
                villageEntity.Description = description;
                villageEntity.Image = image;
                villageEntity.RegionId = regionId;

                _context.Villages
                    .Update(villageEntity);

                await _context.SaveChangesAsync();
            }

            return villageEntity;
        }

        public async Task<bool> Remove(Guid id)
        {
            try
            {
                var villageEntity = await Get(id);

                if (villageEntity != null)
                {
                    _context.Villages
                        .Remove(villageEntity);

                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<VillageEntity>> Search(string query)
        {
            var villageEntities = await _context.Villages
                .AsNoTracking()
                .Where(v => v.Title.ToLower().Contains(query.ToLower()))
                .ToListAsync();

            return villageEntities;
        }
    }
}
