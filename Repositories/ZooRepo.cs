using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models;
using ZooManagement.Models.Database;
using ZooManagement.Request;

namespace ZooManagement.Repositories
{
    public interface IZooRepo
    {
        Animal GetAnimalById(int id);
        IEnumerable<string> GetAllSpecies();
        string AddAnimal(AddAnimalRequest addAnimalRequest);
        Enclosure GetEnclosureByType(EnclosureType enclosureType);
        Enclosure CreateAndReturnEnclosureByType(EnclosureType enclosureType);
        Species GetSpeciesByType(string speciesType);
        Species CreateAndReturnSpecies(string speciesType, ClassificationType classificationType);
        Classification GetClassificationByType(ClassificationType classificationType);
        Classification CreateAndReturnClassificationByType(ClassificationType classificationType);
        IEnumerable<Animal> SearchAnimalsByFilters(SearchRequest searchRequest);
        string AddZooKeeper(AddZooKeeperRequest addZooKeeperRequest);
        ZooKeeper GetZooKeeperById(int id);
    }

    public class ZooRepo : IZooRepo
    {
        private readonly ILogger<ZooRepo> _logger;
        private readonly ZooDbContext _context;

        public ZooRepo(ILogger<ZooRepo> logger, ZooDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Animal GetAnimalById(int id)
        {
            return _context.Animals
                .Where(a => a.Id == id)
                .Include(e => e.Enclosure)
                .Include(s => s.Species)
                .ThenInclude(c => c.Classification)
                .FirstOrDefault();
        }

        public IEnumerable<string> GetAllSpecies() => _context.Species.Select(s => s.Type);

        public string AddAnimal(AddAnimalRequest addAnimalRequest)
        {
            var enclosure = GetEnclosureByType(addAnimalRequest.Enclosure) ?? CreateAndReturnEnclosureByType(addAnimalRequest.Enclosure);

            if (enclosure.Capacity <= enclosure.Animals.Count)
            {
                //throw new Exception("Enclosure Capacity Already Reached");
                Console.WriteLine("Enclosure capacity already reached, animal not added to Zoo.db");
                return "Enclosure capacity already reached, animal not added to Zoo.db";
            }

            var species = GetSpeciesByType(addAnimalRequest.Species) ?? CreateAndReturnSpecies(addAnimalRequest.Species, addAnimalRequest.Classification);

            _context.Animals.Add(new Animal
            {
                Name = addAnimalRequest.Name,
                DateOfBirth = addAnimalRequest.DateOfBirth,
                DateAcquired = addAnimalRequest.DateAquired,
                Sex = addAnimalRequest.Sex,
                Enclosure = enclosure,
                Species = species
            });
            _context.SaveChanges();
            return "Animal Successfully added to Zoo.db";
        }


        public Enclosure GetEnclosureByType(EnclosureType enclosureType)
        {
            return _context.Enclosures
                 .Where(e => e.Type == enclosureType)
                 .Include(e => e.Animals)
                 .FirstOrDefault();
        }

        public Enclosure CreateAndReturnEnclosureByType(EnclosureType enclosureType)
        {
            var checkExists = _context.Enclosures.Where(e => e.Type == enclosureType).FirstOrDefault();
            if (checkExists != null)
            {
                //throw new Exception($"Enclosure: {enclosureType} already existis in the Zoo.db database. Enclosure not added to db.");
                Console.WriteLine($"Enclosure: {enclosureType} already existis in the Zoo.db database. Enclosure not added to db.");
                return null;
            }
            var enclosure = new Enclosure
            {
                Type = enclosureType,
                Capacity = EnclosureDictionary.KeyValues[enclosureType]
            };
            _context.Enclosures.Add(enclosure);
            _context.SaveChanges();

            return GetEnclosureByType(enclosureType);
        }

        public Species GetSpeciesByType(string speciesType)
        {
            return _context.Species
                .Where(s => s.Type == speciesType)
                .Include(s => s.Classification)
                .FirstOrDefault();
        }

        public Species CreateAndReturnSpecies(string speciesType, ClassificationType classificationType)
        {
            var checkExists = _context.Species.Where(s => s.Type == speciesType).FirstOrDefault();
            if (checkExists != null)
            {
                //throw new Exception($"The Species {speciesType} already existis in the Zoo.db database. Species not added to db.");
                Console.WriteLine($"The Species {speciesType} already existis in the Zoo.db database. Species not added to db.");
                return null;
            }

            var classification = GetClassificationByType(classificationType) ?? CreateAndReturnClassificationByType(classificationType);
            var species = new Species
            {
                Type = speciesType,
                Classification = classification
            };
            _context.Species.Add(species);
            _context.SaveChanges();

            return GetSpeciesByType(speciesType);
        }

        public Classification GetClassificationByType(ClassificationType classificationType)
        {
            return _context.Classifications
                .Where(c => c.Type == classificationType).FirstOrDefault();
        }

        public Classification CreateAndReturnClassificationByType(ClassificationType classificationType)
        {
            var checkExists = _context.Classifications.Where(c => c.Type == classificationType).FirstOrDefault();
            if (checkExists != null)
            {
                //throw new Exception($"Classification {classificationType} already existis in the Zoo.db database. Classification not added to db.");
                Console.WriteLine($"Classification {classificationType} already existis in the Zoo.db database. Classification not added to db.");
                return null;
            }
            var classification = new Classification
            {
                Type = classificationType
            };
            _context.Classifications.Add(classification);
            _context.SaveChanges();

            return GetClassificationByType(classificationType);
        }

        public IEnumerable<Animal> SearchAnimalsByFilters(SearchRequest searchRequest)
        {
            var ageRange = GetFilterAgeRange(searchRequest.FilterAge);

            var animals = _context.Animals
                .Where(a => string.IsNullOrEmpty(searchRequest.FilterSpecies) || a.Species.Type == searchRequest.FilterSpecies)
                .Where(a => string.IsNullOrEmpty(searchRequest.FilterName) || a.Name == searchRequest.FilterName)
                .Where(a => searchRequest.FilterAge == null || (a.DateOfBirth > ageRange[0] && a.DateOfBirth < ageRange[1]))
                .Where(a => searchRequest.FilterAcquired == null || a.DateAcquired == searchRequest.FilterAcquired)
                .Where(a => searchRequest.FilterClassification == null || a.Species.Classification.Type == searchRequest.FilterClassification)
                .Where(a => searchRequest.FilterEnclosure == null || a.Enclosure.Type == searchRequest.FilterEnclosure)
                .Include(a => a.Species)
                .ThenInclude(s => s.Classification)
                .Include(a => a.Enclosure);

            return OrderAnimals(animals, searchRequest.FilterOrderDesending, searchRequest.FilterOrderProperty)
                .Skip((searchRequest.Page - 1) * searchRequest.PageSize)
                .Take(searchRequest.PageSize);
        }

        private IList<DateTime> GetFilterAgeRange(int? age)
        {
            var calcAge = age ?? -1;
            var today = DateTime.Now;
            var oldestAgeDate = today.AddYears(-1 * calcAge);
            var youngestAgeDate = today.AddDays(-1);
            youngestAgeDate.AddYears(-1 * (calcAge - 1));

            return new List<DateTime> { youngestAgeDate, oldestAgeDate };
        }

        private IEnumerable<Animal> OrderAnimals(IEnumerable<Animal> animals, bool? filterOrderDescending, Order? filterOrderProperty)
        {
            if (filterOrderDescending == false)
            {
                switch (filterOrderProperty)
                {
                    case Order.DateAcquired:
                        animals = animals.OrderBy(a => a.DateAcquired);
                        break;
                    case Order.Classification:
                        animals = animals.OrderBy(a => a.Species.Classification.Type.ToString());
                        break;
                    case Order.AnimalName:
                        animals = animals.OrderBy(a => a.Name);
                        break;
                    case Order.Enclosure:
                        animals = animals.OrderBy(a => a.Enclosure.Type.ToString()).ThenBy(a => a.Name);
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
                    case Order.DateAcquired:
                        animals = animals.OrderByDescending(a => a.DateAcquired);
                        break;
                    case Order.Classification:
                        animals = animals.OrderByDescending(a => a.Species.Classification.Type.ToString());
                        break;
                    case Order.AnimalName:
                        animals = animals.OrderByDescending(a => a.Name);
                        break;
                    case Order.Enclosure:
                        animals = animals.OrderByDescending(a => a.Enclosure.Type.ToString()).ThenBy(a => a.Name);
                        break;
                    default:
                        animals = animals.OrderByDescending(a => a.Species.Type.ToString());
                        break;
                }
            }
            return animals;
        }

        public string AddZooKeeper(AddZooKeeperRequest addZooKeeperRequest)
        {
            var enclosures = new List<Enclosure>();
            foreach (var enclosureType in addZooKeeperRequest.EnclosureTypes)
            {
                enclosures.Add(GetEnclosureByType(enclosureType) ?? CreateAndReturnEnclosureByType(enclosureType));

            }      
            
            _context.ZooKeepers.Add(new ZooKeeper
            {
                Name = addZooKeeperRequest.Name,
                Enclosures = enclosures,
              
            });
            _context.SaveChanges();
            return "Zoo Keeper Successfully added to Zoo.db";
        }
        public ZooKeeper GetZooKeeperById(int id)
        {
            return _context.ZooKeepers
                .Where(z => z.Id == id)
                .Include(z => z.Enclosures)
                .ThenInclude(e => e.Animals)
                .ThenInclude(a => a.Species)
                .ThenInclude(s => s.Classification)
                .FirstOrDefault();
        }

    }
}