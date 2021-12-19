using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(Guid id)
        {
            return _context.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public void CreatePlatform(Platform plat)
        {
            if (plat == null) throw new ArgumentNullException(nameof(plat));
            _context.Platforms.Add(plat);
        }
    }
}