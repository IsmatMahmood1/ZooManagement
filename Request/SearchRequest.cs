using System;
using ZooManagement.Models;

namespace ZooManagement.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string FilterSpecies { get; set; }
        public ClassificationType? FilterClassification { get; set; }
        public int? FilterAge { get; set; }
        public string FilterName { get; set; }
        public EnclosureType? FilterEnclosure { get; set; }
        public DateTime? FilterAcquired { get; set; }
        public Order? FilterOrderProperty { get; set; }
        public bool? FilterOrderDesending { get; set; }
        public int? FilterZooKeeperId { get; set; }
    }
}

