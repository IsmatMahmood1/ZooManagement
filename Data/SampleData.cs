using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Data;

namespace ZooManagement.Data
{
    public class SampleData
    {

        public static void GenerateData()
        { }
            private List<int> slassificationType = new List<int> { 1, 2, 3, 4, 5, 6 };
            private List<int> sexType = new List<int> { 1, 2 };
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

        private static Animal CreateRandomAnimal(int index)
        {
            return new Animal
            {
                Name = animal[index][0],
                DateOfBirth = DateTime.Parse(animal[index][1]),
                DateAcquired = DateTime.Parse(animal[index][2]),
                Sex = new Random()
            }
            }
    }
        

        
}
       

