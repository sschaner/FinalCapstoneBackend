using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCapstoneBackend.DataTransferObjects.TrailApi
{
    public class TrailApiResult
    {
        public int results { get; set; }
        public List<Trail> data { get; set; }
    }
}
