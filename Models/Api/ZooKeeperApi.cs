using System.Collections.Generic;

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
