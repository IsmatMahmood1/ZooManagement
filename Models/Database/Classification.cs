using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public enum ClassificationType
    {
        Mammal,
        Reptile,
        Bird,
        Insect,
        Fish,
        Invertebrate
    }

    public class Classification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ClassificationType Type { get; set; }

    }
}