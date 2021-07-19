using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public enum Sex
    {
        Male,
        Female
    }

    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateAcquired { get; set; }

        public Sex Sex { get; set; }

        public Enclosure Enclosure { get; set; }
        public Classification Classification { get; set; }
        public Species Species { get; set; }

    }
}