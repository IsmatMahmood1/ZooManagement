using System.Collections.Generic;

namespace ZooManagement.Models.Database
{
    public class Enclosure
    {
        public int Id { get; set; }

        public EnclosureType Type { get; set; }

        public int Capacity { get; set; }
        public int Count { get; set; }
        public List<Animal> Animals { get; set; }
    }
}