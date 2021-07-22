using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZooManagement.Models.Database;

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
