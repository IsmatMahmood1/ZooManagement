using System.Collections.Generic;
using ZooManagement.Models.Database;
using System.Linq;

namespace ZooManagement.Models.Api
{
    public class ZooKeeperApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> EnclosureIds { get; set; }
        public List<AnimalApi> Animals { get; set; }

        public ZooKeeperApi(ZooKeeper zookeeper) 
        {
            Id = zookeeper.Id;
            Name = zookeeper.Name;
            EnclosureIds = zookeeper.Enclosures.Select(e => e.Id);
            Animals = new List<AnimalApi>();
            foreach(var enclosure in zookeeper.Enclosures)
            {
                foreach( var animal in enclosure.Animals)
                {
                    Animals.Add(new AnimalApi(animal));
                }
            }
        }
    }

}
