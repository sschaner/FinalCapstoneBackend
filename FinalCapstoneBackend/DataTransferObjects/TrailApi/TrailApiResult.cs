using System.Collections.Generic;

namespace FinalCapstoneBackend.DataTransferObjects.TrailApi
{
    public class TrailApiResult
    {
        public int results { get; set; }
        public List<Trail> data { get; set; }
    }
}
