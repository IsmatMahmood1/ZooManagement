using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public enum EnclosureType
    {
        Lion,
        Aviary,
        Reptile,
        Giraffe,
        Hippo,
        Invertebrate
    }

    public class Enclosure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public EnclosureType Type { get; set; }
        
        public int Capacity { get; set; }
        public int Count { get; set; }

    }
}