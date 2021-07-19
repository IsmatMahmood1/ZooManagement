using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public class Classification
    {
        public int Id { get; set; }

        public ClassificationType Type { get; set; }

        public List<Species> Species { get; set; }
    }
}