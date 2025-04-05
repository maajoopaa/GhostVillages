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
    public class RegionService : IRegionService
    {
        private readonly GhostVillagesDbContext _context;

        public RegionService(GhostVillagesDbContext context)
        {
            _context = context;
        }

        public async Task<RegionEntity?> Get(Guid id)
        {
            var regionEntity = await _context.Regions
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);

            return regionEntity;
        }

        public async Task<List<RegionEntity>> GetList()
        {
            var regionEntities = await _context.Regions
                .AsNoTracking()
                .ToListAsync();

            return regionEntities;
        }

        public async Task<RegionEntity> Create(string title, string description, byte[] image)
        {
            var regionEntity = new RegionEntity
            {
                Title = title,
                Description = description,
                Image = image
            };

            await _context.Regions
                .AddAsync(regionEntity);

            await _context.SaveChangesAsync();

            return regionEntity;
        }

        public async Task<RegionEntity?> Update(Guid id, string title, string description, byte[] image)
        {
            var regionEntity = await Get(id);

            if (regionEntity != null)
            {
                regionEntity.Title = title;
                regionEntity.Description = description;
                regionEntity.Image = image;

                _context.Regions
                    .Update(regionEntity);

                await _context.SaveChangesAsync();
            }

            return regionEntity;
        }

        public async Task<bool> Remove(Guid id)
        {
            try
            {
                var regionEntity = await Get(id);

                if (regionEntity != null)
                {
                    _context.Regions
                        .Remove(regionEntity);

                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
