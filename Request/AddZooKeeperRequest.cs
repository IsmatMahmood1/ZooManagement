using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZooManagement.Request
{
    public class AddZooKeeperRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IEnumerable<int> EnclosureIds { get; set; }
    }
}
