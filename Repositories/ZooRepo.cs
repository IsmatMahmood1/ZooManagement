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
        string AddAnimal(AddAnimalRequest addAnimalRequest);
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

        public string AddAnimal(AddAnimalRequest addAnimalRequest)
        {
            var enclosure = GetEnclosureByType(addAnimalRequest.Enclosure) ?? CreateAndReturnEnclosureByType(addAnimalRequest.Enclosure);

            if (enclosure.Capacity <= enclosure.Animals.Count)
            {
                throw new Exception("Enclosure Capacity Already Reached");
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
            return "Animal Successfully added to Database";
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
            var checkExists = _context.Enclosures.Where(e => e.Type == enclosureType);
            if (checkExists != null)
            {
                throw new Exception($"Enclosure: {enclosureType} already existis in the Zoo.db database. Enclosure not added to db.");
            }
            var enclosure = new Enclosure
            {
                Type = enclosureType,
                Capacity = EnclosureDictionary.KeyValues[enclosureType]
            };
            _context.Enclosures.Add(enclosure);
            _context.SaveChanges();

            return enclosure;
        }

        public Species GetSpeciesByType(string speciesType)
        {
            return _context.Species
                .Where(s => s.Type == speciesType).FirstOrDefault();
        }

        public Species CreateAndReturnSpecies(string speciesType, ClassificationType classificationType)
        {
            var checkExists = _context.Species.Where(s => s.Type == speciesType);
            if (checkExists != null)
            {
                throw new Exception($"The Species {speciesType} already existis in the Zoo.db database. Species not added to db.");
            }

            var classification = GetClassificationByType(classificationType) ?? CreateAndReturnClassificationByType(classificationType);
            var species = new Species
            {
                Type = speciesType,
                Classification = classification
            };
            _context.Species.Add(species);
            _context.SaveChanges();

            return species;
        }

        public Classification GetClassificationByType(ClassificationType classificationType)
        {
            return _context.Classifications
                .Where(c => c.Type == classificationType).First();
        }

        public Classification CreateAndReturnClassificationByType(ClassificationType classificationType)
        {
            var checkExists = _context.Classifications.Where(c => c.Type == classificationType);
            if (checkExists != null)
            {
                throw new Exception($"Classification {classificationType} already existis in the Zoo.db database. Classification not added to db.");
            }
            var classification = new Classification
            {
                Type = classificationType
            };
            _context.Classifications.Add(classification);
            _context.SaveChanges();

            return classification;
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

        public IList<DateTime> GetFilterAgeRange(int? age)
        {
            var calcAge = age ?? -1;
            var today = DateTime.Now;
            var oldestAgeDate = today.AddYears(-1 * calcAge);
            var youngestAgeDate = today.AddDays(-1);
            youngestAgeDate.AddYears(-1 * (calcAge - 1));

            return new List<DateTime> { youngestAgeDate, oldestAgeDate };
        }

        public IEnumerable<Animal> OrderAnimals(IEnumerable<Animal> animals, bool? filterOrderDescending, Order? filterOrderProperty)
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
                        animals = animals.OrderBy(a => a.Enclosure.Type.ToString());
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
                        animals = animals.OrderByDescending(a => a.Enclosure.Type.ToString());
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