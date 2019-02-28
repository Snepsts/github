using System;
using Newtonsoft.Json;

namespace Github.Models
{
    public class User
    {        
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
