using System.Collections.Generic;

namespace ZooManagement.Models.Database
{

    public class Species
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Classification Classification { get; set; }
        public List<Animal> Animal { get; set; }
    }
}