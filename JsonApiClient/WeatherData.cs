using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JsonApiClient
{
    [DataContract]
    public class WeatherData
    {
        [DataMember]
        public double message { get; set; }
        [DataMember]
        public string cod { get; set; }
        [DataMember]
        public string calctime { get; set; }
        [DataMember]
        public int cnt { get; set; }
        [DataMember]
        public List<List> list { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public int humidity { get; set; }
        public int pressure { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double gust { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class List
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public double distance { get; set; }
        public Main main { get; set; }
        public int dt { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public List<Weather> weather { get; set; }
    }

}
