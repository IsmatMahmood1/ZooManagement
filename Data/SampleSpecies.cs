using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleSpecies
    {
        public static int NumberOfClassifications = 10;

        private static IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Lion" },
            new List<string> { "Monkey" },
            new List<string> { "Parrot" },
            new List<string> { "Giraffe" },
            new List<string> { "Hippo" },
            new List<string> { "Snake" },
            new List<string> { "Gorilla" },
            new List<string> { "Gecko" },
            new List<string> { "Spiders" },
            new List<string> { "Tuna" }
        };


        private static Species CreateRandomSpecies(string index, List<Classifications> classifications)
        {
            return new Species
            {
                Type = _data[index][0],
                Classification = _data[index][1]

            };
        }
    }
}