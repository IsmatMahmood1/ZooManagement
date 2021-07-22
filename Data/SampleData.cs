using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Data;
using ZooManagement.Models;

namespace ZooManagement.Data
{
    public class SampleData
    {
        private static List<ClassificationType> classificationType = new List<ClassificationType> { ClassificationType.Mammal, ClassificationType.Bird, ClassificationType.Fish, ClassificationType.Reptile, 
            ClassificationType.Insect, ClassificationType.Invertebrate };
        private static  EnclosureType enclosureType = EnclosureType.Lion;
        private static List<string> speciesType = new List<string> { "Lion", "Hippo", "Gorilla", "Spider", "Penguin", "Octopus", "Zebra", "Bear", "Bat", "Parrot" };

        private static IList<IList<string>> animal = new List<IList<string>>
            {
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"George", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Bob", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Todd", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Tom", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Dave", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Megan", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Boris", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Daisy", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Rachel", DateTime.Now.ToString(), DateTime.Now.ToString() },
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() }
            };

        public static IEnumerable<Animal> GetAnimals()
        {
            var enclosure = GenerateEnclosure(enclosureType);
            var classifications =  classificationType.Select(ct => GenerateClassification(ct)).ToList();
            var species = speciesType.Select(st => GenerateSpecies(st, classifications)).ToList();
            return Enumerable.Range(0, 100).Select( i => CreateRandomAnimal(i, species, enclosure));
        }

        public static Species GenerateSpecies(string type, IList<Classification> classifications)
        {
            return new Species
            {
                Type = type,
                Classification = classifications[new Random().Next(6)]
            };
        }

        public static Classification GenerateClassification(ClassificationType type)
        {
            return new Classification
            {
                Type = type
            };
        }

        public static Enclosure GenerateEnclosure(EnclosureType type)
        {
            return new Enclosure
            {
                Type = type,
                Capacity = EnclosureDictionary.keyValues[type]
            };
        }

        private static Animal CreateRandomAnimal(int index, IList<Species> species, Enclosure enclosure)
        {
            return new Animal
            {
                Name = animal[index][0],
                DateOfBirth = DateTime.Parse(animal[index][1]),
                DateAcquired = DateTime.Parse(animal[index][2]),
                Sex = (Sex) new Random().Next(1,3),
                Species = species[new Random().Next(9)],
                Enclosure = enclosure
            };
        }
    }       
}
       

