using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public class SampleData
    {
        private static readonly List<ClassificationType> classificationType = new List<ClassificationType> { ClassificationType.Mammal, ClassificationType.Bird, ClassificationType.Fish, ClassificationType.Reptile,
            ClassificationType.Insect, ClassificationType.Invertebrate };
        private static readonly List<string> speciesType = new List<string> { "Lion", "Hippo", "Gorilla", "Spider", "Penguin", "Octopus", "Zebra", "Bear", "Bat", "Parrot" };
        public static readonly Dictionary<EnclosureType, string> _enclosuresAndZooKeepers = new Dictionary<EnclosureType, string>()
        {
            {EnclosureType.Lion, "Dave"},
            {EnclosureType.Giraffe, "Miranda"},
            {EnclosureType.Hippo, "Joe"},
            {EnclosureType.Aviary, "Sandra"},
            {EnclosureType.Reptile, "Hab"},
            {EnclosureType.Invertebrate, "Joao"}
        };
        private static readonly IList<IList<string>> animal = new List<IList<string>>
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
            var enclosures = GenerateEnclosures(_enclosuresAndZooKeepers);
            var classifications = classificationType.Select(ct => GenerateClassification(ct)).ToList();
            var species = speciesType.Select(st => GenerateSpecies(st, classifications)).ToList();
            return CreateAllRandomAnimals(species, enclosures);
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

        public static List<Enclosure> GenerateEnclosures(Dictionary<EnclosureType, string> dictionary)
        {
            List<Enclosure> enclosures = new List<Enclosure>();
            foreach (var pair in dictionary)
            {
                var zooKeeper = new ZooKeeper()
                {
                    Name = pair.Value
                };
                enclosures.Add(new Enclosure
                {
                    Type = pair.Key,
                    Capacity = EnclosureDictionary.KeyValues[pair.Key],
                    ZooKeepers = new List<ZooKeeper> { zooKeeper }
                });
            }
            return enclosures;
        }

        private static List<Animal> CreateAllRandomAnimals(IList<Species> species, IList<Enclosure> enclosures)
        {
            List<Animal> animals = new List<Animal>();
            foreach (var row in animal)
            {
                animals.Add(new Animal
                {
                    Name = row[0],
                    DateOfBirth = DateTime.Parse(row[1]),
                    DateAcquired = DateTime.Parse(row[2]),
                    Sex = (Sex)new Random().Next(1, 3),
                    Species = species[new Random().Next(9)],
                    Enclosure = enclosures[new Random().Next(5)]
                });
            }
            return animals;
        }
    }
}


