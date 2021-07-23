using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZooManagement.Models;

namespace ZooManagement.Request
{
    public class AddZooKeeperRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<EnclosureType> EnclosureTypes{ get; set; }
    }
}
