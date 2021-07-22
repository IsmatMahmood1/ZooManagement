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
            var enclosure = GetEnclosureByType(addAnimalRequest.Enclosure);

            if (enclosure.Capacity <= enclosure.Animals.Count)
            {
                throw new Exception("Enclosure Capacity Already Reached");
            }

            var existingSpecies = GetSpeciesByType(addAnimalRequest.Species);

            // Need to add in validation to make sure species exists otherwise we might not get back an object and need
            // to create one which potentially involves creating a classificaiton. 

            _context.Animals.Add(new Animal
            {
                Name = addAnimalRequest.Name,
                DateOfBirth = addAnimalRequest.DateOfBirth,
                DateAcquired = addAnimalRequest.DateAquired,
                Sex = addAnimalRequest.Sex,
                Enclosure = enclosure,
                Species = existingSpecies
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

        public void CreateEnclosureByType(EnclosureType enclosureType)
        {
            var checkExists = _context.Enclosures.Where(e => e.Type == enclosureType);
            if (checkExists != null)
            {
                throw new Exception($"Enclosure: {enclosureType} already existis in the Zoo.db database. Enclosure not added to db.");
            }
            _context.Enclosures.Add(new Enclosure
            {
                Type = enclosureType,
                Capacity = EnclosureDictionary.keyValues[enclosureType]
            });
            _context.SaveChanges();
        }

        public Species GetSpeciesByType(string speciesType)
        {
            return _context.Species
                .Where(s => s.Type == speciesType).FirstOrDefault();
        }
        
        public void CreateSpecies(string speciesType, Classification classification)
        {
            var checkExists = _context.Species.Where(s => s.Type == speciesType);
            if (checkExists != null)
            {
                throw new Exception($"The Species {speciesType} already existis in the Zoo.db database. Species not added to db.");
            }
            _context.Species.Add(new Species
            {
                Type = speciesType,
                Classification = classification
            }) ;
            _context.SaveChanges();
        }

        public void CreateClassificationByType(ClassificationType classificationType)
        {
            var checkExists = _context.Classifications.Where(c => c.Type == classificationType);
            if (checkExists != null)
            {
                throw new Exception($"Classification {classificationType} already existis in the Zoo.db database. Classification not added to db.");
            }
            _context.Classifications.Add(new Classification
            {
                Type = classificationType
            });
            _context.SaveChanges();
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
           .Where(a => searchRequest.FilterEnclosure == null || a.Enclosure.Type == searchRequest.FilterEnclosure)
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
                    case "Enclosure":
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
                    case "DateAcquired":
                        animals = animals.OrderByDescending(a => a.DateAcquired);
                        break;
                    case "Classification":
                        animals = animals.OrderByDescending(a => a.Species.Classification.Type.ToString());
                        break;
                    case "AnimalName":
                        animals = animals.OrderByDescending(a => a.Name);
                        break;
                    case "Enclosure":
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