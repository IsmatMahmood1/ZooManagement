using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Repositories;

namespace ZooManagement.Repositories
{
    public interface IZooRepo
    {
        Animal SearchAnimalById(int id);
    }

    public class ZooRepo : IZooRepo
    {
        private readonly ZooDbContext _context;

        public ZooRepo(ZooDbContext context)
        {
            _context = context;
        }

        public Animal SearchAnimalById(int id)
        {
            return _context.Animals
                .Where(a => a.Id == id)
                .Include(e => e.Enclosure)
                .Include(s => s.Species)
                .ThenInclude(c => c.Classification)
                .First();
        }
    }

}