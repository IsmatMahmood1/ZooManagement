using System;

namespace ZooManagement.Models.Database
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateAcquired { get; set; }
        public Sex Sex { get; set; }
        public Enclosure Enclosure { get; set; }
        public Species Species { get; set; }
    }
}