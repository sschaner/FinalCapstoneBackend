namespace FinalCapstoneBackend.DataTransferObjects.WeatherApi
{
    public class WeatherApiResult
    {
        public LocationApiResult location { get; set; }
        public CurrentApiResult current { get; set; }
    }
}
