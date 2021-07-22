using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManagement.Models.Database
{
    public class ZooKeeper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Enclosure> Enclosures { get; set; }
    }
}
