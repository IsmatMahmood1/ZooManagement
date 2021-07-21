using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models;
using ZooManagement.Models.Database;
using ZooManagement.Repositories;
using ZooManagement.Request;

namespace ZooManagement.Repositories
{
    public interface IZooRepo
    {
        Animal SearchAnimalById(int id);
        IEnumerable<string> GetAllSpecies();
        IEnumerable<Animal> SearchAnimalsByFilters(SearchRequest searchRequest);

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

        public IEnumerable<string> GetAllSpecies()
        {
            return _context.Species.Select(s => s.Type);
        }

        public IEnumerable<Animal> SearchAnimalsByFilters(SearchRequest searchRequest)
        {


            return _context.Animals
               .OrderByDescending(a => a.Species)
               .Where(a => searchRequest.FilterSpecies == "All" || a.Species.Type == searchRequest.FilterSpecies)
               .Where(a => searchRequest.FilterName == "All" || a.Name == searchRequest.FilterName)
               .Where(a => searchRequest.FilterAquired == default(DateTime) || a.DateAcquired == searchRequest.FilterAquired)
               .Where(a => searchRequest.FilterClassification == null || a.Species.Classification.Type == searchRequest.FilterClassification)
               .Include(a => a.Species)
               .ThenInclude(s => s.Classification)
               .Include(a => a.Enclosure)
               .Skip((searchRequest.Page - 1) * searchRequest.PageSize)
               .Take(searchRequest.PageSize);

            //    FilterSpecies { get; set; } = "All";
            //public string FilterClassification { get; set; } = "All";
            //public string FilterAge { get; set; } = "All";
            //public string FilterName { get; set; } = "All";
            //public string FilterAquired { get; set; } = "All";
            //public string FilterOrderProperty { get; set; } = "Name";
            //public bool FilterOrderDesending { get; set; } = true;

            //discuss with oskar how to get age from dbmodel?
            //ordering by property@ end
        }
    }
}