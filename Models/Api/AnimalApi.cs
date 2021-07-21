using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Api
{
    public class AnimalApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateAcquired { get; set; }
        public string Sex { get; set; }
        public int EnclosureId { get; set; }
        public string EnclosureType { get; set; }
        public string SpeciesName { get; set; }
        public string SpeciesClassification { get; set; }

        public AnimalApi(Animal animalDb)
        {
            Id = animalDb.Id;
            Name = animalDb.Name;
            Sex = animalDb.Sex.ToString();
            Age = GetAge(animalDb.DateOfBirth);
            SpeciesName = animalDb.Species.Type;
            SpeciesClassification = animalDb.Species.Classification.Type.ToString();
            DateOfBirth = animalDb.DateOfBirth;
            DateAcquired = animalDb.DateAcquired;
            EnclosureId = animalDb.Enclosure.Id;
            EnclosureType = animalDb.Enclosure.Type.ToString();
        }
        private int GetAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}


