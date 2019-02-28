using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Github.Models
{
    public class Repo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }
        
        [JsonProperty("owner")]
        public User Owner { get; set; }
        
        [JsonProperty("stargazers")]
        public List<User> Stargazers { get; set; }
    }
}
