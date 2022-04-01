using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCapstoneBackend.DataTransferObjects.TrailApi
{
    public class Trail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string length { get; set; }
        public string description { get; set; }
        public string directions { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string difficulty { get; set; }
        public string features { get; set; }
        public decimal rating { get; set; }
        public string thumbnail { get; set; }
    }
}
