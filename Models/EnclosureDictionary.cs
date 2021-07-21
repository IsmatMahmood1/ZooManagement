using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManagement.Models
{
    public class EnclosureDictionary
    {
        public Dictionary<string, int> keyValues = new Dictionary<string, int>()
        {
            {EnclosureType.Lion.ToString(), 10},
            {EnclosureType.Giraffe.ToString(), 6},
            {EnclosureType.Hippo.ToString(), 10},
            {EnclosureType.Aviary.ToString(), 50},
            {EnclosureType.Reptile.ToString(), 40},
            {EnclosureType.Invertebrate.ToString(), 100}
        };
    }
}
