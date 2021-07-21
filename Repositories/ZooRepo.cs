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
            var ageRange = FilterAgeRange(searchRequest.FilterAge);

            var animals = _context.Animals
           .Where(a => searchRequest.FilterSpecies == "All" || a.Species.Type == searchRequest.FilterSpecies)
           .Where(a => searchRequest.FilterName == "All" || a.Name == searchRequest.FilterName)
           .Where(a => searchRequest.FilterAge == -1 || (a.DateOfBirth > ageRange[0] && a.DateOfBirth < ageRange[1]))
           .Where(a => searchRequest.FilterAquired == default(DateTime) || a.DateAcquired == searchRequest.FilterAquired)
           .Where(a => searchRequest.FilterClassification == null || a.Species.Classification.Type == searchRequest.FilterClassification)
           .Include(a => a.Species)
           .ThenInclude(s => s.Classification)
           .Include(a => a.Enclosure);

            return OrderAnimals(animals, searchRequest.FilterOrderDesending, searchRequest.FilterOrderProperty)
           .Skip((searchRequest.Page - 1) * searchRequest.PageSize)
           .Take(searchRequest.PageSize);
        }

        public IList<DateTime> FilterAgeRange(int age)
        {
            var today = DateTime.Now;
            var oldestAgeDate = today.AddYears(-1 * age);
            var youngestAgeDate = today.AddDays(-1);
            youngestAgeDate.AddYears(-1 * (age - 1));

            return new List<DateTime> { youngestAgeDate, oldestAgeDate };
        }

        public IEnumerable<Animal> OrderAnimals(IEnumerable<Animal> animals, bool filterOrderDescending, string filterOrderProperty)
        {
            if (filterOrderDescending == false)
            {
                switch (filterOrderProperty)
                {
                    case "DateAcquired":
                        animals = animals.OrderBy(a => a.DateAcquired);
                        break;
                    case "Classification":
                        animals = animals.OrderBy(a => a.Species.Classification.Type.ToString());
                        break;
                    case "AnimalName":
                        animals = animals.OrderBy(a => a.Name);
                        break;
                    default:
                        animals = animals.OrderBy(a => a.Species.Type.ToString());
                        break;
                }
            }
            else
            {
                switch (filterOrderProperty)
                {
                    case "DateAcquired":
                        animals = animals.OrderByDescending(a => a.DateAcquired);
                        break;
                    case "Classification":
                        animals = animals.OrderByDescending(a => a.Species.Classification.Type.ToString());
                        break;
                    case "AnimalName":
                        animals = animals.OrderByDescending(a => a.Name);
                        break;
                    default:
                        animals = animals.OrderByDescending(a => a.Species.Type.ToString());
                        break;
                }
            }
            return animals;
        }
    }
}