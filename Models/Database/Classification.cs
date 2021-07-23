using System.Collections.Generic;

namespace ZooManagement.Models.Database
{
    public class Classification
    {
        public int Id { get; set; }
        public ClassificationType Type { get; set; }
        public List<Species> Species { get; set; }
    }
}