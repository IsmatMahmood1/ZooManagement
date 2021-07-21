using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooManagement.Models;

namespace ZooManagement.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string FilterSpecies { get; set; } = "All";
        public ClassificationType? FilterClassification { get; set; }
        public string FilterAge { get; set; } = "All";
        public string FilterName { get; set; } = "All";
        public DateTime FilterAquired { get; set; } = default(DateTime);
        public string FilterOrderProperty { get; set; } = "Name";
        public bool FilterOrderDesending { get; set; } = true;
    }
}

