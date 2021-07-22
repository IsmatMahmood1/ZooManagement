using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManagement.Models.Api
{
    public class ZooKeeperApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> EnclosureIds { get; set; }
        public IEnumerable<AnimalApi> Animals { get; set; }
    }
}
