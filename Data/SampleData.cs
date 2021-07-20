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
        private List<ClassificationType> classificationType = new List<ClassificationType> { ClassificationType.Mammal, ClassificationType.Bird, ClassificationType.Fish, ClassificationType.Reptile, 
            ClassificationType.Insect, ClassificationType.Invertebrate };
        private List<Sex> sexType = new List<Sex> { Sex.Male, Sex.Female };
        private int enclosureType = 1;
        private List<string> speciesType = new List<string> { "Lion", "Hippo", "Gorilla", "Spider", "Penguin", "Octopus", "Zebra", "Bear", "Bat", "Parrot" };

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
                new List<string> {"Fred", DateTime.Now.ToString(), DateTime.Now.ToString() }
            };

        public static void GenerateData()
        {
            var Animals = Enumerable.Range(0, 10).Select( i => CreateRandomAnimal(i, Generate));


        }

        public static Species GenerateSpecies(string type, Classification classification)
        {
            return new Species
            {
                Type = type,
                Classification = classification
            };
        }

        //Classifications

        //Enclosure
            

        private static Animal CreateRandomAnimal(int index, List<Species> species)
        {
            return new Animal
            {
                Name = animal[index][0],
                DateOfBirth = DateTime.Parse(animal[index][1]),
                DateAcquired = DateTime.Parse(animal[index][2]),
                Sex = (Sex) new Random().Next(1, 2),
                Species = species[new Random().Next(5)]
            };
        }
    }       
}
       

