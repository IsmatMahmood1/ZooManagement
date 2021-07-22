using System;
using System.ComponentModel.DataAnnotations;
using ZooManagement.Models;
namespace ZooManagement.Request
{
    public class AddAnimalRequest
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public  Sex Sex { get; set; }
        [Required]
        public ClassificationType Classification { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public EnclosureType Enclosure { get; set; }
        [Required]
        public DateTime DateAquired { get; set; }

    }
}