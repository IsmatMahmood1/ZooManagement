using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManagement.Models
{
    public static class EnclosureDictionary
    {
        public static  Dictionary<EnclosureType, int> keyValues = new Dictionary<EnclosureType, int>()
        {
            {EnclosureType.Lion, 10},
            {EnclosureType.Giraffe, 6},
            {EnclosureType.Hippo, 10},
            {EnclosureType.Aviary, 50},
            {EnclosureType.Reptile, 40},
            {EnclosureType.Invertebrate, 100}
        };
    }
}
